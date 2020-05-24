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
}
