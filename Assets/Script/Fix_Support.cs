using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static partial class Fix
{
  public const string PRACTICE_CLAW = "練習用の爪";
  public const string FINE_CLAW = "ファイン・クロー";
  public const string SURVIVAL_CLAW = "サバイバル・クロー";
  public const string RISING_FORCE_CLAW = "ライジング・フォース・クロー";
  public const string LIGHTNING_CLAW = "電光の爪";
  public const string PRACTICE_SWORD = "練習用の剣";
  public const string FINE_SWORD = "ファイン・ソード";
  public const string BRONZE_SWORD = "ブロンズ・ソード";
  public const string SWORD_OF_LIFE = "ソード・オブ・ライフ";
  public const string AERO_BLADE = "疾風の剣";
  public const string MERGIZD_SOL_BLADE = "Mergizd Sol Blade";
  public const string FINE_LANCE = "ファイン・ランス";
  public const string SHARP_LANCE = "シャープ・ランス";
  public const string WHITE_PARGE_LANCE = "ホワイトパージ・ランス";
  public const string ICE_SPIRIT_LANCE = "氷魂の槍";
  public const string FINE_BOW = "ファイン・ボウ";
  public const string ELVISH_BOW = "エルヴィッシュ・ボウ";
  public const string ICICLE_LONGBOW = "アイシクル・ロングボウ";
  public const string MUMYOU_BOW = "無明の弓";
  public const string FINE_AXE = "ファイン・アックス";
  public const string VIKING_AXE = "バイキング・アックス";
  public const string EARTH_POWER_AXE = "土力の斧";
  public const string WARWOLF_AXE = "ワーウルフ・アックス";
  public const string PRACTICE_ORB = "練習用のオーブ";
  public const string FINE_ORB = "ファイン・オーブ";
  public const string ENERGY_ORB = "エナジー・オーブ";
  public const string LIVING_GROWTH_ORB = "リビング・グロース・オーブ";
  public const string RED_PILLER_ORB = "炎柱の水晶玉";
  public const string FINE_ROD = "ファイン・ロッド";
  public const string WOOD_ROD = "ウッド・ロッド";
  public const string TOUGH_TREE_ROD = "頑丈な樫の杖";
  public const string BLACK_SORCERER_ROD = "ブラック・ソーサラー・ロッド";
  public const string FINE_BOOK = "ファイン・ブック";
  public const string KINDNESS_BOOK = "カインドネス・ブック";
  public const string SAINT_FAITHFUL_BOOK = "セイント・フェイスフル・ブック";
  public const string MUIN_BOOK = "無印の魔導書";
  public const string FINE_SHIELD = "ファイン・シールド";
  public const string KITE_SHIELD = "カイト・シールド";
  public const string SUPERIOR_FLAME_SHIELD = "スペリオル・フレイム・シールド";
  public const string BEGINNER_ARMOR = "初心者の鎧";
  public const string FINE_ARMOR = "ファイン・アーマー";
  public const string BEGINNER_CROSS = "初心者の舞踏衣";
  public const string FINE_CROSS = "ファイン・クロス";
  public const string BEGINNER_ROBE = "初心者のローブ";
  public const string FINE_ROBE = "ファイン・ローブ";
  public const string FLAT_SHOES = "フラット・シューズ";
  public const string COMPACT_EARRING = "コンパクト・イヤリング";
  public const string POWER_BANDANA = "パワー・バンダナ";
  public const string CHERRY_CHOKER = "チェリー・チョーカー";
  public const string RED_PENDANT = "レッド・ペンダント";
  public const string BLUE_PENDANT = "ブルー・ペンダント";
  public const string PURPLE_PENDANT = "パープル・ペンダント";
  public const string GREEN_PENDANT = "グリーン・ペンダント";
  public const string YELLOW_PENDANT = "イエロー・ペンダント";
  public const string BLUE_WIZARD_HAT = "ブルー・ウィザード・ハット";
  public const string FLAME_HAND_KEEPER = "フレイム・ハンド・キーパー";
  public const string SMALL_RED_POTION = "小さい赤ポーション";
  public const string NORMAL_RED_POTION = "普通の赤ポーション";
  public const string LARGE_RED_POTION = "大きな赤ポーション";
  public const string SMART_CLAW = "スマート・クロー";
  public const string DANCING_CLAW = "ダンシング・クロー";
  public const string SMART_SWORD = "スマート・ソード";
  public const string CUTTING_BLADE = "カッティング・ブレード";
  public const string SMART_LANCE = "スマート・ランス";
  public const string SWIFT_SPEAR = "スウィフト・スピア";
  public const string SMART_BOW = "スマート・ボウ";
  public const string LONG_BOW = "ロング・ボウ";
  public const string SMART_AXE = "スマート・アックス";
  public const string POWERED_AXE = "パワード・アックス";
  public const string SMART_ORB = "スマート・オーブ";
  public const string FOCUS_ORB = "フォーカス・オーブ";
  public const string SMART_ROD = "スマート・ロッド";
  public const string AUTUMN_ROD = "オータムン・ロッド";
  public const string SMART_BOOK = "スマート・ブック";
  public const string BULKY_BOOK = "バルキー・ブック";
  public const string SMART_SHIELD = "スマート・シールド";
  public const string WIDE_BUCKLER = "ワイド・バックラー";
  public const string SMART_ARMOR = "スマート・アーマー";
  public const string GOTHIC_PLATE = "ゴシック・プレート";
  public const string SMART_CROSS = "スマート・クロス";
  public const string LETHER_CROSS = "レザー・クロス";
  public const string SMART_ROBE = "スマート・ローブ";
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
  public const string ZETANIUM_STONE = "ゼタニウム鉱石";
  public const string FIELD_RESEARCH_LICENSE = "国内外遠征許可証";
  public const string ITEM_MATOCK = "マトック";
  public const string ITEM_TOOMI_AOSUISYOU = "遠見の青水晶";
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
}
