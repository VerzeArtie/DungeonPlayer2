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
    Swordman,
    Archer,
    Armorer,
    Rogue,
    EnhanceForm,
    MysticForm,
    Brave,
    Mindfulness,
    None,
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
  public const int BASE_TIMER_BAR_LENGTH = 10000;
  public const int BASE_TIMER_DIV = 12;
  public const int TIMER_ICON_NUM = 8;
  public const int MAX_INSTANT_POINT = 100;
  public const int GLOBAL_INSTANT_MAX = 100;
  public const int AP_BASE = 100;
  public const int INFINITY = 9999999;

  // Color
  public static Color COLOR_NORMAL = Color.black;
  public static Color COLOR_HEAL = Color.green;

  public static Color COLOR_FIRST_CHARA = new Color(235.0f / 255.0f, 253.0f / 255.0f, 255.0f / 255.0f);
  public static Color COLORFORE_FIRST_CHARA = new Color(0, 185.0f / 255.0f, 255.0f / 255.0f);

  public static Color COLOR_SECOND_CHARA = new Color(255.0f / 255.0f, 208.0f / 255.0f, 244.0f / 255.0f);
  public static Color COLORFORE_SECOND_CHARA = new Color(255.0f / 255.0f, 124.0f / 255.0f, 170.0f / 255.0f);

  public static Color COLOR_THIRD_CHARA = new Color(255.0f / 255.0f, 245.0f / 255.0f, 189.0f / 255.0f);
  public static Color COLORFORE_THIRD_CHARA = new Color(248.0f / 255.0f, 237.0f / 255.0f, 95.0f / 255.0f);

  public static Color COLOR_FOURTH_CHARA = new Color(189.0f / 255.0f, 255.0f / 255.0f, 199.0f / 255.0f);
  public static Color COLORFORE_FOURTH_CHARA = new Color(0 / 255.0f, 187.0f / 255.0f, 0 / 255.0f);

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
  public const string BATTLE_AP_LESS = "No AP";
  public const string BATTLE_BIND = "Bind";
  public const string BATTLE_DIVINE = "Divine";

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
  public const int CHARACTER_LIST_NUM = 23;
  public const string NAME_EIN_WOLENCE = @"アイン ウォーレンス";
  public const string NAME_LANA_AMIRIA = @"ラナ アミリア";
  public const string NAME_EONE_FULNEA = @"エオネ フルネア";
  public const string NAME_MAGI_ZELKIS = @"マーギ ゼルキス";
  public const string NAME_SELMOI_RO = @"セルモイ ロウ";
  public const string NAME_KARTIN_MAI = @"カーティン マイ";
  public const string NAME_JEDA_ARUS = @"ジェダ アルス";
  public const string NAME_SINIKIA_VEILHANZ = @"シニキア ヴェイルハンツ";
  public const string NAME_ADEL_BRIGANDY = @"アデル ブリガンディ";
  public const string NAME_LENE_COLTOS = @"レネ コルトス";
  public const string NAME_PERMA_WARAMY = @"ペルマ ワラミィ";
  public const string NAME_KILT_JORJU = @"キルト ジョルジュ";
  public const string NAME_BILLY_RAKI = @"ビリー ラキ";
  public const string NAME_ANNA_HAMILTON = @"アンナ ハミルトン";
  public const string NAME_CALMANS_OHN = @"カルマンズ オーン";
  public const string NAME_SUN_YU = @"サン ユウ";
  public const string NAME_SHUVALTZ_FLORE = @"シュヴァルツェ フローレ";
  public const string NAME_RVEL_ZELKIS = @"ルベル ゼルキス";
  public const string NAME_VAN_HEHGUSTEL = @"ヴァン ヘーグステル";
  public const string NAME_OHRYU_GENMA = @"オウリュウ ゲンマ";
  public const string NAME_LADA_MYSTORUS = @"ラダ ミストゥルス";
  public const string NAME_SIN_OSCURETE = @"シン オスキュレーテ";
  public const string NAME_DELVA_TRECKINO = @"デルバ トレッキーノ";
  #endregion

  #region "Enemy Name"
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
  public const string OLD_TREEFORK = "Old Treefork";
  public const string OLD_TREEFORK_JP = "古びたツリーフォーク";
  public const string SUN_FLOWER = "Sun Flower";
  public const string SUN_FLOWER_JP = "サン フラワー";
  public const string SOLID_BEETLE = "Sold Beetle";
  public const string SOLID_BEETLE_JP = "甲殻ビートル";
  public const string SILENT_LADYBUG = "Silent Ladybug";
  public const string SILENT_LADYBUG_JP = "物静かなレディバグ";
  public const string MYSTIC_DRYAD = "Mystic Dryad";
  public const string MYSTIC_DRYAD_JP = "神秘的なドライアド";
  public const string NIMBLE_RABBIT = "Nimble Rabbit";
  public const string NIMBLE_RABGIT_JP = "軽快なラビット";
  public const string ENTANGLED_VINE = "Entangled Vine";
  public const string ENTANGLED_VINE_JP = "絡みつく蔦";
  public const string CREEPING_SPIDER = "Creeping Spider";
  public const string CREEPING_SPIDER_JP = "忍び寄るスパイダー";
  public const string BLOOD_MOSS = "Blood Moss";
  public const string BLOOD_MOSS_JP = "ブラッド モス";
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
  public const string KILLER_BEE = "Killer Bee";
  public const string KILLER_BEE_JP = "キラー ビー";
  public const string POISON_MARY = "Poison Mary";
  public const string POISON_MARY_JP = "ポイズン マリー";
  public const string FLANSIS_OF_THE_FOREST_QUEEN = "Flansis of the Forest Queen";
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
  public const string BLACK_OCTOPUS_JP = "ブラック・オクトパス";
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
  public const string MAGICAL_HAIL_GUN = "Magical Hail-Gun";
  public const string MAGICAL_HAIL_GUN_JP = "魔法雹穴銃";

  public const string _ = "";
  public const string _JP = "";
  #endregion

  #region "Event"
  public static List<string> QUEST_EVENT_TITLE = new List<string>() {
    "国内外遠征許可証の入手",
    "国王エルミからの依頼",
    "鍛冶屋ヴァスタと会話",
    "ゼタニウム鉱石を採取",
    "港町コチューシェへ",
    "ObsidianStoneの使い方",
    "試練の道 【茨】",
    "(Optional) ゴラトルム洞窟の探索",
    "ファージル宮殿への報告（ObsidianStone）",
    "キージク山道を抜けて",
    "ファージル宮殿への報告（異変に関する報告）",
    "海底神殿：ヴェルガス",
    "中立国：ムーンフォーダー",
    "見捨てられた廃墟の村：サリタン",
    "忍び寄る凶兆の表れ",
    "封印門：ダル",
    "焼かれし都にて",
    "難攻不落の要塞",
    "(Optional) 未開の地下洞窟ロスロン",
    "終戦：エデルガイゼン城",
    "神具の欠片",
    "里にまつわる伝説の神具",
    "【理】の起源：シス",
    "ラタ：すべてを遂げし者",
    "雪原の大樹に眠りしは叡智の印",
    "原罪ウォズム",
    "隠されしファージル宮殿の最深部",
    "神具が指し示すは、世界の【理】",
    "【理】世界創生の試練",
    "【理】起源滅亡の試練",
    "【理】無限回廊の試練",
    "究極の選択"
   };

  public static List<string> QUEST_EVENT_MESSAGE = new List<string>()
  {
    "ファージル宮殿へと向かい、遠征許可証を入手しよう。ファージル宮殿はアンシェットの町から川沿いに北へ進めば見えてくる。身支度が整い次第、すぐに出発しよう。",
    "国内外遠征許可証を受理した際、国王エルミよりファージルエリアの港町コチューシェへ赴き調査を行うように依頼された。港町コチューシェはファージル区域の東側の海沿いにある。まずは東方面へ遠征してみよう。",
    "鍛冶屋ヴァスタに会いに行こう。ヴァスタはクヴェルタ街に住んでいる。",
    "ゼタニウム鉱石を５つ採取する様に依頼された。ゼタニウム鉱石はアーサリウム工場跡地のどこかにある様だ。謎のアイテムの正体を掴むためにも是非とも採取してこよう。",
    "謎のアイテムを鑑定した結果、本アイテムは部材の一つであることが判明した。他の部材については港町コチューシェで見かけたらしい。港町コチューシェへ向かおう。",
    "謎のアイテムはObsidianStoneと呼ばれる物であり、人類に叡智をもたらす物である。このアイテムの詳細についてはツァルマンの里の長老が知っている。ツァルマンの里へ赴き、そのアイテムの使い方を伝授してもらおう。",
    "ツァルマンとは実在する人物の名称ではなく、遥か過去よりこの里の秘境の場所に存在する何かを表わすワードであるという事を告げられた。ObsidianStoneについてはツァルマンと呼ばれる存在から詳細を聞いたほうが良いと長老から告げられた。試練の道【茨】へ挑みツァルマンとコンタクトを取ろう。",
    "里の長老からはゴラトルム洞窟については決して赴いては行けないと言われている。しかし、存在「ツァルマン」からは「挑む姿勢と、遂げる意志」の助言をもらっている。ゴラトルム洞窟へは赴くべきか・・・",
    "ObsidianStoneに関する情報は一通り得られた。いったんファージル宮殿へ帰還し、その内容をエルミおよびファラに報告しよう。",
    "ファージル宮殿から北東に向かうと、キージク山道がある。その山道の頂上にはオーランの塔が設置されている。その塔に赴き、周辺地域に何か変わった所が無いか見てきてほしいと依頼された。オーランの塔へ向かい、周辺地域に異常が起きていないか確認してこよう。",
    "オーランの塔から周辺を確認すると、いくつか異変がある箇所が確認された。ファージル宮殿へ帰還し、その内容をエルミおよびファラに報告しよう。",
    "「フィオーネの湖」中央に位置するヴェルガスの神殿は普段歩いては行けない箇所であるが、閉鎖されていた「洗状橋」が何者かによって可動させられているとの報告が入った。ヴェルガスの神殿には多くの未知なるモンスターが住んでおり、非常に危険である事が知られている。ヴェルガスの神殿へ赴き、神殿の状況を確認する事となった。",
    "ヴェルガスの神殿にて遭遇した人物から、中立国：ムーンフォーダー区域への入国許可証を得た。ムーンフォーダー区域内において、現在もなお不穏な出来事が発生しているため、その正体を突き止めるべく、まずは「清信者」達が集うアーケンダイン街へ入り情報を収集して欲しいとの依頼を連絡を受けた。",
    "アーケンダイン街の人々から聞いた情報によると、今は人が住んでいない廃墟サリタンにたびたび出入りしている不審な人物が目撃されている。廃墟サリタンに出入りしている人物を突き止めよう。",
    "廃墟サリタンで遭遇した人物は、神話王国の首都を収める国王本人だった。国王はつい先刻実施した神聖儀式により、凶兆のお告げを得ており、そこでは海底神殿ヴェルガスと廃墟サリタンに古来より封印せしObisidianStoneに関連する事象であるとの見解を得たとのこと。そのため、現在保持しているObisidianStoneを持って今すぐ神話王国の首都パルメティシアに訪れるように依頼された。",
    "ObisidianStoneに関する歴史をより深く紐解くため、ヴィンスガルデ王国へと続く「ダルの門」を開く事が必要である事をパルメティシア王より告げられた。王より受け取った鍵を用いて「ダルの門」を開き、ヴィンスガルデ王国にあるディル街へ訪問してほしいとの依頼を受けた。",
    "ディル街の人々は酷く荒んでいた。街が荒廃した理由は過去に起きた「戦乱ウォズム」により「主要都市ディスケル」が壊滅状態にさせられた事に起因する事が明らかとなった。ディスケルの跡地に赴き、まずは死者達の元へ酒と花を持っていき、弔いの儀式を行って欲しいようだ。",
    "死者の弔いを行い、ディル街に住む人々へその行いを伝えた。その結果、ディル街の人々は今の圧政に苦しむ事を嘆く事を止め、捨て身の決起を行い、ガンロー要塞への突撃を決意した。ガンロー要塞に向かい、ディル街の人々と共にガンロー要塞の総指揮官を打ち倒そう。",
    "ガンロー要塞より得た情報によると、エデルガイゼン城へ向かうまでの間、水面上を通過する事の出来る幻のルートが存在する事が判明している。そのルートを抜けた先には、未踏の地下洞窟ロスロンがあると言われている。幻のルートを探し、洞窟ロスロンを探索してみよう。",
    "当初、国王エルミから告げられた主目的はヴィンスガルデ王国へ赴き、その様子を探ってくる事だった。今となっては、その真意は明確であり、疑念をはさむ余地は無い。確固たる決意を秘めて、エデルガイゼン城へと向かおう。終戦はすぐそこまで来ている。",
    "エデルガイゼン城の国王よりある内容が伝えられた。それは、このエリア全域にまつわる神話の一つとして神具フェルトゥーシュにまつわる話だ。エデルガイゼン城の王より託されたパーツはその神具フェルトゥーシュの一部だという。この神具を完成させ、真の平和を志して欲しいと託されたのである。神具については、この城の先にある箇所にヒントを示す碑文があるというのだが、今はそこまで行く道筋は見えていない。一度ファージル宮殿へ戻り、国王エルミと相談してみよう。",
    "ファージル宮殿に国王エルミ、王妃ファラは居なかった。何が起きており、何が始まってしまったのか、彼らはまだ何一つ知らない状態に陥り困惑を隠せないでいた。そこへ王室の近衛隊長サンディより伝言が告げられた。「我を追い求めるは隠されし真実を追求する者。ツァルマンの里へ赴き、内なる扉を開くがよい。」　姿を消した国王と王妃を追うべく、ツァルマンの里へと向かおう。",
    "ゼールマンの里の長老より国王エルミおよび王妃ファラがここを訪れていた事を伝えられた。彼らの目的は伝説の神具を入手する事。伝説の神具はこの世界の【理】そのものであり、それを手にした者は絶対無二の力を会得することを教えられた。彼らは、この【理】を会得して全世界を支配しようとしている事が明らかとなった。国王と王妃を食い止めるべく、まずは【理】の起源を指し示す「シスの墓標」へと向かい、その【理】とは何であるかを知る必要があるだろう。",
    "墓標にて姿を現した思念体のシス。その存在から伝えられた内容は驚くべきものだった。【理】は存在に対する干渉律を示すものではなく、この世界の形成そのものを指すという内容である。戸惑いながらも伝えられた内容を受け止めた結果、国王エルミと王妃ファラが目指すべき地点が明らかとなった。本大陸の片隅にひっそりとそびえたつ「ラタの緑小屋」。そこには伝説の神具を構築するために必要な物理事象が隠されているとの事。国王と王妃が向かった先へと歩を進めよう。",
    "ラタの小屋で国王エルミと王妃ファラに遭遇し、会話を終えたその直後だった。彼らは転送の儀式を詠唱し、姿を消し去ったのだ。行先については詳しくは語られなかったが、その直後に床に置かれていた手紙には次のように記載されていた。【ウォズムの原罪を断ち切る。力を貸して欲しい】。ウォズムの地は聖なる区域とされており、原則立ち入る事は許されていない。立ち入るためには、ムーンフォーダー区域にある雪原の大樹に宿る生命体と接触し、叡智の印を授与する事。進むべき道は決まった。今すぐ雪原の大樹へ向かおう。",
    "雪原の大樹より「叡智の印」を授かり、国王エルミと同じ転送の儀式を習得した。目指す目的地は離島ウォズム。そこに何があるのか。何が起こるのか。何が迫っているのか。ファージル国王エルミの想いは計りないが、それを知るために転送の儀式を使い、離島ウォズムの地へ足を運ぼう。今、すべてが明らかになる。",
    "国王エルミは離島ウォズムの地で永眠した。その姿を惜しむ間もなく、その場に思念体シスが現れ、これから起こる事象について告げられた。その内容は、世界における【理】が崩れつつある事、そしてそれを食い止めるためには、今手元に入手している伝説の神具を完成体にさせる必要があるという事だ。完成体にする方法はただ一つ。ファージル宮殿が建設された地点の中央最深部に赴き、この世界の「るつぼ」と呼ばれる地点に到着する事。そしてその地点にある【無限螺旋の鏡】に神具かざそう。",
    "伝説の神具：フェルトゥーシュが完成した。同時に思念体となったエルミからは、これまでに起きた様々な事象はすべて確実に予期されていた【定め】である事が伝えられた。ここから先は思念体となったエルミ、そしてシスにも【定め】は見えていない。手元の神具フェルトゥーシュはただただ光を放ち続ける。指し示すは一点【天上界ジェネシスゲート】。そこには世界の【理】そのものが存在する。神具を手にし、固い決意を秘め、【天上界ジェネシスゲート】へと駆け上がるのだ。",
    "【理】が示すは世界の創生にまつわる過去の歴史。天上界ジェネシスゲートの第一層を探索し、世界の創生に関する事象を見定めよう。そして、第二層へと通じている【天翔の門】へと赴き,本階層をクリアしよう。",
    "【理】が示すは起源滅亡にまつわる未来の定め。天上界ジェネシスゲートの第二層を探索し、起源の滅亡に関する事象を見定めよう。そして、第三層へと通じている【深淵の門】へと赴き,本階層をクリアしよう。",
    "【理】が示すは無限回廊にまつわる現在そのもの。天上界ジェネシスゲートの第三層を探索し、現世の渦に関する事象を見定めよう。そして、最終層へと通じている【無因の門】へと赴き、本階層をクリアしよう。",
    "【理】は【すべて】を【選択】によって終わらせようとしている。【すべて】とは何か。そして選ぶべき【選択】とは何か。【理】が示した【究極の選択】と相対し【解】を提示しよう。",
  };
  #endregion

  #region "Action Command"
  // GlobalCommand
  public const string READY_BUTTON = "ReadyButton";
  public const string GO_BUTTON = "GoButton";
  public const string STOP_BUTTON = "StopButton";
  public const string RUNAWAY_BUTTON = "RunAwayButton";

  // ActionCommand
  public const string NORMAL_ATTACK = "Normal Attack";
  public const string MAGIC_ATTACK = "Magic Attack";
  public const string Defense = "Defense";
  public const string Stay = "Stay";
  public const string USE_RED_POTION = "RedPotion";

  // ActionCommand [ Delve I ]
  public const string FIRE_BOLT = "Fire Bolt";
  public const string ICE_NEEDLE = "Ice Needle";
  public const string FRESH_HEAL = "Fresh Heal";
  public const string SHADOW_BLAST = "Shadow Blast";
  public const string AURA_OF_POWER = "Aura of Power";
  public const string SKY_SHIELD = "Sky Shield";
  public const string STRAIGHT_SMASH = "Straight Smash";
  public const string SHIELD_BASH = "Shield Bash";
  public const string HUNTER_SHOT = "Hunter Shot";
  public const string VENOM_SLASH = "Venom Slash";
  public const string HEART_OF_LIFE = "Heart of Life";
  public const string ORACLE_COMMAND = "Oracle Command";

  // Devle II
  public const string STANCE_OF_THE_BLADE = "Stance of the Blade";
  public const string STANCE_OF_THE_GUARD = "Stance of the Guard";
  public const string MULTIPLE_SHOT = "Multiple Shot";
  public const string INVISIBLE_BIND = "Invisible Bind";
  public const string FORTUNE_SPIRIT = "Fortune Spirit";
  public const string ZERO_IMMUNITY = "Zero Immunity";
  public const string DIVINE_CIRCLE = "Divine Circle";
  public const string BLOOD_SIGN = "Blood Sign";
  public const string FLAME_BLADE = "Flame Blade";
  public const string PURE_PURIFICATION = "Pure Purification";
  public const string STORM_ARMOR = "Storm Armor";
  public const string DISPEL_MAGIC = "Dispel Magic";
  public const string FLASH_COUNTER = "Flash Counter";

  public const string CIRCLE_SLASH = "Circle Slash";
  public const string PHANTASMAL_WIND = "Phantasmal Wind";

  // Delve III
  public const string DOUBLE_SLASH = "Double Slash";
  public const string CONCUSSIVE_HIT = "Concussive Hit";
  public const string REACHABLE_TARGET = "Reachable Target";
  public const string IRREGULAR_STEP = "Irregular Step";
  public const string VOICE_OF_VIGOR = "Voice of Vigor";
  public const string SPIRITUAL_REST = "Spiritual Rest";
  public const string HOLY_BREATH = "Holy Breath";
  public const string DEATH_SCYTHE = "Death Scythe";
  public const string METEOR_BULLET = "Meteor Bullet";
  public const string BLUE_BULLET = "Blue Bullet";
  public const string AETHER_DRIVE = "Aether Drive";
  public const string MUTE_IMPULSE = "Mute Impulse";

  // Delve IV
  public const string WAR_SWING = "War Swing";
  public const string DOMINATION_FIELD = "Domination Field";
  public const string HAWK_EYE = "Hawk Eye";
  public const string DISSENSION_RHYTHM = "Dissension Rhythm";
  public const string SIGIL_OF_THE_FAITH = "Sigil of the Faith";
  public const string ESSENCE_OVERFLOW = "Essence Overflow";
  public const string SANCTION_FIELD = "Sanction Field";
  public const string WHISPER_VOICE = "Whisper Voice";
  public const string FLAME_STRIKE = "Flame Strike";
  public const string FREEZING_CUBE = "Freezing Cube";
  public const string CIRCLE_OF_THE_POWER = "Circle of the Power";
  public const string DETACHMENT_FAULT = "Detachment Fault";

  // Delve V
  public const string KINETIC_SMASH = "Kinetic Smash";
  public const string SAFETY_FIELD = "Safety Field";
  public const string PIERCING_ARROW = "Piercing Arrow";
  public const string ASSASSINATION_HIT = "Assassination Hit";
  public const string RAGING_STORM = "Raging Storm";
  public const string INNER_INSPIRATION = "Inner Inspiration";
  public const string VALKYRIE_BREAK = "Valkyrie Break";
  public const string ABYSS_EYE = "Abyss Eye";
  public const string SIGIL_OF_THE_HOMURA = "Sigil of the Homura";
  public const string FROST_LANCE = "Frost Lance";
  public const string RUNE_STRIKE = "Rune Strike";
  public const string PHANTOM_OBORO = "Phantom Oboro";

  // Delve VI
  public const string STANCE_OF_THE_IAI = "Stance of the Iai";
  public const string OATH_OF_AEGIS = "Oath of Aegis";
  public const string WIND_RUNNER = "Wind Runner";
  public const string KILLER_GAZE = "Killer Gaze";
  public const string SOUL_SHOUT = "Soul Shout";
  public const string EVERFLOW_MIND = "Everflow Mind";
  public const string SHINING_HEAL = "Shining Heal";
  public const string THE_DARK_INTENSITY = "The Dark Intensity";
  public const string PIERCING_FLAME = "Piercing Flame";
  public const string WATER_SPLASH = "Water Splash";
  public const string WORD_OF_THE_REVOLUTION = "Word of the Revolution";
  public const string TRANQUILITY = "Tranquility";

  // Delve VII
  public const string DESTROYER_SMASH = "Destroyer Smash";
  public const string ONE_IMMUNITY = "One Immunity";
  public const string DEADLY_ARROW = "Deadly Arrow";
  public const string CARNAGE_RUSH = "Carnage Rush";
  public const string OVERWHELMING_DESTINY = "Overwhelming Destiny";
  public const string TRANSCENDENCE_REACHED = "Transcendence Reached";
  public const string RESURRECTION = "Resurrection";
  public const string DEMON_CONTRACT = "Demon Contract";
  public const string LAVA_ANNIHILATION = "Lava Annihilation";
  public const string ABSOLUTE_ZERO = "Absolute Zero";
  public const string BRILLIANT_FORM = "Brilliant Form";
  public const string TIME_SKIP = "Time Skip";

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
  public const string COMMAND_POISON_RINPUN = "毒の鱗粉";
  public const string COMMAND_YOUEN_FIRE = "妖艶なる炎";
  public const string COMMAND_BLAZE_DANCE = "ブレイズ・ダンス";
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

  public const string EFFECT_POWERUP_FIRE = "UP Fire";
  public const string EFFECT_POWERUP_ICE = "UP Ice";
  public const string EFFECT_POWERUP_LIGHT = "UP Light";
  public const string EFFECT_POWERUP_SHADOW = "UP Shadow";

  public const string BUFF_RESIST_STUN = "Resist Stun";
  public const string EFFECT_RESIST_STUN = "Stun耐性";
  public const string EFFECT_REMOVE_STUN = "Stun除去";
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

  public const string DUNGEON_ARTHARIUM_FACTORY = "アーサリウム工場跡地";
  public const string DUNGEON_GORATRUM_CAVE = "ゴラトルムの洞窟";
  public const string DUNGEON_VELGUS_SEA_TEMPLE = "ヴェルガス海底神殿";
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

  #region "DungeonMapFile"
  public const string MAPFILE_BASE_FIELD = "MapData_BaseField.txt";
  public const string MAPFILE_ARTHARIUM = "MapData_Artharium.txt";
  public const string MAPFILE_GORATRUM = "MapData_Goratrum.txt";
  public const string MAPFILE_VELGUS = "MapData_Velgus.txt";
  public const string MAPFILE_OHRAN = "MapData_Ohran.txt";
  public const string MAPFILE_SARITAN = "MapData_Saritan.txt";
  public const string MAPFILE_SNOWTREELATA = "MapData_SnowTreeLata.txt";
  public const string MAPFILE_DISKEL = "MapData_Diskel.txt";
  public const string MAPFILE_GANRO = "MapData_Ganro.txt";
  public const string MAPFILE_LOSLON = "MapData_Loslon.txt";
  public const string MAPFILE_EDELGARZEN = "MapData_EdelGaizen.txt";
  public const string MAPFILE_GENESISGATE = "MapData_GenesisGate.txt";
  #endregion
}
