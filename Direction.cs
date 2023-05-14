namespace HeartbeatHunter
{
  /// <summary>
  ///   The "Direction" enum
  ///
  ///   Represents the idea of north, south, east and west.
  /// </summary>
  enum Direction
    {
      North,
      South,
      East,
      West
    }

  static class DirectionExtensions
  {
    public static Direction Opposite(this Direction direction)
    {
      switch (direction)
      {
        case Direction.North:
          return Direction.South;
        case Direction.South:
          return Direction.North;
        case Direction.East:
          return Direction.West;
        case Direction.West:
          return Direction.East;
        default:
          throw new ArgumentException("Invalid direction.");
      }
    }
  }
}
