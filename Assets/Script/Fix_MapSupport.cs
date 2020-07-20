using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Fix
{
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
  public const float OHRANTOWER_Treasure_7_X = 1f;
  public const float OHRANTOWER_Treasure_7_Y = 29f;
  public const float OHRANTOWER_Treasure_7_Z = 22f;

  public const string OHRANTOWER_Treasure_8_C = "Treasure";
  public const string OHRANTOWER_Treasure_8_O = "8";
  public const float OHRANTOWER_Treasure_8_X = -3f;
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

}
