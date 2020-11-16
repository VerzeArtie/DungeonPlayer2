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
    // アーサリウム工場跡地
    Artharium_Normal = 1001,
    Artharium_Wall = 1002,
    Artharium_Debris = 1003,
    Artharium_Poison = 1004,
    Artharium_Bridge1 = 1005,
    Artharium_Bridge2 = 1006,
    Artharium_Gate = 1007,
    // オーランの塔
    Ohran_Normal = 2001,
    Ohran_Wall = 2002,
    Ohran_FloatTile = 2003,
    Ohran_WarpHole = 2004,
    // ヴェルガスの海底神殿
    // 3000
    // ダルの門
    Dhal_Normal = 4001,
    Dhal_Wall = 4002,
    Dhal_NormalObj = 4003,
    Dhal_WallObj = 4004,

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

      // アーサリウム工場跡地
      if (field == Field.Artharium_Normal) { return 1; }
      if (field == Field.Artharium_Debris) { return 1; }
      if (field == Field.Artharium_Poison) { return 1; }
      if (field == Field.Artharium_Bridge1) { return 1; }
      if (field == Field.Artharium_Bridge2) { return 1; }
      if (field == Field.Artharium_Gate) { return 999; }
      if (field == Field.Artharium_Wall) { return 999; }

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
      return 999;
    }
  }

  public string ObjectId = String.Empty;

  public List<TileInformation> connectNode = new List<TileInformation>();

  public int cost = -1; //探索に要したコスト。-1の時はそのノードを未探索としています。
  public TileInformation toGoal = null; //ゴールへの最短ルートにつながるノード
}
