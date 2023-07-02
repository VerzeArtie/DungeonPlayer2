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
    Boss,
  }

  public Content content = Content.None;

  public string ObjectId = String.Empty;
}
