using System;

namespace HeartbeatHunter
{
  /// <summary>
  ///   The Exit class.
  ///
  ///   A class representing an exit from a location :)
  /// </summary>
  class Exit
  {
    public Direction Direction { get; set; }
    public Location Destination { get; set; }

    public Exit(Direction direction, Location destination)
    {
      Direction = direction;
      Destination = destination;
    }
  }
}
