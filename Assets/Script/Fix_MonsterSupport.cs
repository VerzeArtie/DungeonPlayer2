using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static partial class Fix
{
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
}