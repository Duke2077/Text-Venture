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

  static class StringExtensions
  {
    /// <summary>
    ///   Tells us if a direction name exists.
    /// </summary>
    public static bool IsValidDirection(this string direction)
    {
      switch (direction)
      {
        case "North":
        case "South":
        case "East":
        case "West":
          return true;
        default:
          return false;
      }
    }

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
