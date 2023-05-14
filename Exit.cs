using System;

namespace HeartbeatHunter
{
  /// <summary>
  ///   The Exit class.
  ///
  ///   A class representing an exit from a place :)
  /// </summary>
  class Exit
  {
    public Direction Direction { get; set; }
    public Place Destination { get; set; }

    public Exit(Direction direction, Place destination)
    {
      Direction = direction;
      Destination = destination;
    }
  }
}
