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

}
