namespace HeartbeatHunter
{
  /// <summary>
  ///   An element that can be examined in this location we're at.
  ///
  ///   An examineable element in this location, place or room.
  /// </summary>
  public class ExamineableElement
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public string ProvideDescription()
    {
      return Description;
    }
  }
}
