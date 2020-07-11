using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Fix
{
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


}
