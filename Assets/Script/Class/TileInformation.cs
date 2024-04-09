using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TileInformation : MonoBehaviour
{
  public enum Field
  {
    // Base-Field
    None = 0,
    Plain = 1,
    Forest = 2,
    Sea = 3,
    Mountain = 4,
    Wall = 5,
    Bridge1 = 6,
    Bridge2 = 7,
    Road_V = 8,
    Road_H = 9,
    Wall_1 = 10,
    Road_RB = 11,
    Road_LB = 12,
    Road_TR = 13,
    Road_TL = 14,
    Town_1 = 15,
    Fountain_1 = 16,
    Castle_1 = 17,
    Dungeon_1 = 18,
    Snow = 19,
    SnowWall = 20,
    Waste = 21,
    WasteWall = 22,
    Upstair = 23,
    Downstair = 24,
    // ゴラトラム洞窟
    Goratrum_Hole = 101,

    // アーサリウム工場跡地
    Artharium_Normal = 1001,
    Artharium_Wall = 1002,
    Artharium_Debris = 1003,
    Artharium_Poison = 1004,
    Artharium_Bridge1 = 1005,
    Artharium_Bridge2 = 1006,
    Artharium_Gate = 1007,
    Artharium_Hole = 1008,
    // オーランの塔
    Ohran_Normal = 2001,
    Ohran_Wall = 2002,
    Ohran_FloatTile = 2003,
    Ohran_WarpHole = 2004,
    // ヴェルガスの海底神殿
    Velgus_Normal = 3001,
    Velgus_Wall = 3002,
    Velgus_Sea = 3003,
    Velgus_Number1 = 3004,
    Velgus_Number2 = 3005,
    Velgus_Number3 = 3006,
    Velgus_Number4 = 3007,
    Velgus_Number5 = 3008,
    Velgus_Number6 = 3009,
    Velgus_Number7 = 3010,
    Velgus_CircleRed = 3011,
    Velgus_CircleBlue = 3012,
    Velgus_CircleGreen = 3013,
    Velgus_CircleYellow = 3014,
    // 3000
    // ダルの門
    Dhal_Normal = 4001,
    Dhal_Wall = 4002,
    Dhal_NormalObj = 4003,
    Dhal_WallObj = 4004,
    
    // 神秘の森
    MysticForest_Normal = 5001,
    MysticForest_Wall = 5002,

    // エデルガイゼン城
    Edelgarzen_Normal = 6001,
    Edelgarzen_Wall = 6002,
    Edelgarzen_Cloud = 6003,
    Edelgarzen_Cloud_Secret = 6004,
  }
  public enum Area
  {
    None = 0,
    AREA_1 = 1,
    AREA_2 = 2,
    AREA_3 = 3,
    AREA_4 = 4,
    AREA_5 = 5,
    AREA_6 = 6,
    AREA_7 = 7,
    AREA_8 = 8,
    AREA_9 = 9,
    AREA_10 = 10,
    AREA_11 = 11,
    AREA_12 = 12,
    AREA_13 = 13,
    AREA_14 = 14,
    AREA_15 = 15,
    AREA_16 = 16,
  }

  public Field field = Field.Plain;

  public int MoveCost
  {
    get
    {
      if (field == Field.Road_H) { return 1; }
      if (field == Field.Road_V) { return 1; }
      if (field == Field.Road_LB) { return 1; }
      if (field == Field.Road_RB) { return 1; }
      if (field == Field.Road_TL) { return 1; }
      if (field == Field.Road_TR) { return 1; }
      if (field == Field.Bridge1) { return 1; }
      if (field == Field.Bridge2) { return 1; }
      if (field == Field.Plain) { return 1; }
      if (field == Field.Forest) { return 2; }
      if (field == Field.Town_1) { return 1; }
      if (field == Field.Fountain_1) { return 1; }
      if (field == Field.Castle_1) { return 1; }
      if (field == Field.Dungeon_1) { return 1; }
      if (field == Field.Snow) { return 1; }
      if (field == Field.Waste) { return 1; }
      if (field == Field.Mountain) { return 999; }
      if (field == Field.None) { return 999; }
      if (field == Field.Wall) { return 999; }
      if (field == Field.SnowWall) { return 999; }
      if (field == Field.WasteWall) { return 999; }
      if (field == Field.Upstair) { return 1; }
      if (field == Field.Downstair) { return 1; }

      // ゴラトラム洞窟
      if (field == Field.Goratrum_Hole) { return 1; }

      // アーサリウム工場跡地
      if (field == Field.Artharium_Normal) { return 1; }
      if (field == Field.Artharium_Debris) { return 1; }
      if (field == Field.Artharium_Poison) { return 1; }
      if (field == Field.Artharium_Bridge1) { return 1; }
      if (field == Field.Artharium_Bridge2) { return 1; }
      if (field == Field.Artharium_Gate) { return 999; }
      if (field == Field.Artharium_Wall) { return 999; }
      if (field == Field.Artharium_Hole) { return 999; }

      // オーランの塔
      if (field == Field.Ohran_Normal) { return 1; }
      if (field == Field.Ohran_Wall) { return 999; }
      if (field == Field.Ohran_FloatTile) { return 1; }
      if (field == Field.Ohran_WarpHole) { return 1; }

      // ダルの門
      if (field == Field.Dhal_Normal) { return 1; }
      if (field == Field.Dhal_Wall) { return 999; }
      if (field == Field.Dhal_NormalObj) { return 1; }
      if (field == Field.Dhal_WallObj) { return 999; }

      // 神秘の森
      if (field == Field.MysticForest_Normal) { return 1; }
      if (field == Field.MysticForest_Wall) { return 999; }

      // ヴェルガスの海底神殿
      if (field == Field.Velgus_Normal) { return 1; }
      if (field == Field.Velgus_Number1) { return 1; }
      if (field == Field.Velgus_Number2) { return 1; }
      if (field == Field.Velgus_Number3) { return 1; }
      if (field == Field.Velgus_Number4) { return 1; }
      if (field == Field.Velgus_Number5) { return 1; }
      if (field == Field.Velgus_Number6) { return 1; }
      if (field == Field.Velgus_Number7) { return 1; }
      if (field == Field.Velgus_CircleRed) { return 1; }
      if (field == Field.Velgus_CircleBlue) { return 1; }
      if (field == Field.Velgus_CircleGreen) { return 1; }
      if (field == Field.Velgus_CircleYellow) { return 1; }
      if (field == Field.Velgus_Wall) { return 999; }
      if (field == Field.Velgus_Sea) { return 999; }

      // エデルガイゼン城
      if (field == Field.Edelgarzen_Normal) { return 1; }
      if (field == Field.Edelgarzen_Wall) { return 999; }
      if (field == Field.Edelgarzen_Cloud) { return 999; }
      if (field == Field.Edelgarzen_Cloud_Secret) { return 1; }

      return 999;
    }
  }

  public Area AreaInfo = Area.None;
  public string ObjectId = String.Empty;

  public List<TileInformation> connectNode = new List<TileInformation>();

  public int cost = -1; //探索に要したコスト。-1の時はそのノードを未探索としています。
  public TileInformation toGoal = null; //ゴールへの最短ルートにつながるノード
}
