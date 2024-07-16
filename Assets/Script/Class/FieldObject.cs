using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FieldObject : MonoBehaviour
{
  public enum Content
  {
    None = 0,
    Treasure,
    Rock,
    Character,
    Fountain,
    MessageBoard,
    Door_Copper,
    Door_Silver,
    Door_Gold,
    Crystal,
    ObsidianStone,
    FloatingTile,
    WarpHole,
    DhalGate_Tile,
    DhalGate_Wall,
    DhalGate_Door,
    Brushwood,
    MysticForest_EventWall,
    OhranTower_Door_ShadowMoon,
    OhranTower_Door_SunBurst,
    OhranTower_Door_StarDust,
    OhranTower_Door_OriginRoad,
    Velgus_WallDoor,
    Velgus_SecretWall,
    Velgus_FakeSea,
    Velgus_BallRed,
    Velgus_BallBlue,
    Velgus_BallGreen,
    Velgus_BallYellow,
    Velgus_CircleRed,
    Velgus_CircleBlue,
    Velgus_CircleGreen,
    Velgus_CircleYellow,
    Velgus_SlidingTile,
    Velgus_FixedTile,
    Velgus_MovingTile1,
    Velgus_MovingTile2,
    Velgus_MovingTile3,
    Velgus_MovingTile4,
    Velgus_MovingTile5,
    Velgus_MovingTile2_1,
    Velgus_MovingTile2_2,
    Velgus_MovingTile2_3,
    Velgus_MovingTile2_4,
    Velgus_MovingTile2_5,
    Velgus_MovingTile2_6,
    Velgus_MovingTile2_7,
    Velgus_MovingTile2_8,
    Velgus_MovingTile3_1,
    Velgus_MovingTile3_2,
    Velgus_MovingTile3_3,
    Velgus_MovingTile3_4,
    Velgus_MovingTile3_5,
    Velgus_MovingTile3_6,
    Velgus_MovingTile3_7,
    Velgus_MovingTile4_1,
    Velgus_MovingTile4_2,
    Velgus_MovingTile4_3,
    Velgus_MovingTile4_4,
    Velgus_MovingTile4_5,
    Velgus_RandomBall,
    Velgus_RandomBall2,
    Edelgarzen_Mirror,
    Edelgarzen_Door,
    Boss,
  }

  public Content content = Content.None;

  public string ObjectId = String.Empty;

  public Vector3 InitPosition = Vector3.zero;
}
