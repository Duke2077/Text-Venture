namespace HeartbeatHunter
{
  /// <summary>
  ///   the room element class
  ///
  ///   A class representing an element of the room that can be observed :)
  /// </summary>
  class LocationElement
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public string ProvideDescription()
    {
      return Description;
    }
  }
}
