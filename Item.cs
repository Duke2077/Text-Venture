  namespace HeartbeatHunter
  {
    /// <summary>
    ///   The Item class.
    ///
    ///   A class representing an item in the game.
    /// </summary>
    class Item
    {
      public string Name { get; set; } /**< The item's name */

      public string PickUpText { get; set; } /**< Description of the item we just pickup up */

      public int SlotsRequired { get; set; } = 1; /**< Slots required to take this item */
    }
  }
