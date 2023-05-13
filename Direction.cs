using System.Collections.Generic; // List<T>

namespace HeartbeatHunter
{
  /// <summary>
  ///   The "Direction" C# struct
  ///
  ///   Represents the idea of north, south, east and west.
  /// </summary>
  struct Direction
  {
    public const string North = "north";
    public const string South = "south";
    public const string East = "east";
    public const string West = "west";

    /// <summary>
    ///   Tells us if a direction name exists.
    /// </summary>
    public static bool IsValidDirection(string direction)
    {
      switch (direction)
      {
        case Direction.North:
          return true;
        case Direction.South:
          return true;
        case Direction.East:
          return true;
        case Direction.West:
          return true;
      }
      return false;
    }

    public static bool operator ==(Direction d1, Direction d2)
    {
      return d1.Value == d2.Value;
    }

    public static bool operator !=(Direction d1, Direction d2)
    {
      return d1.Value != d2.Value;
    }
  }
}
