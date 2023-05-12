  namespace TheHyperionProject
  {
    /// <summary>
    ///   The Item class.
    ///
    ///   A class representing an item in the game.
    /// </summary>
    class Item
    {
      #region Private variables

      //Private properties backing a C# property
      private string itemName;
      private string pickUpText;
      private int slotsRequired = 1;
      #endregion
    
      /// <summary>
      /// Gets or sets the name of this item.
      /// </summary>
      public string ItemName
      {
        get { return itemName; }
        set { itemName = value; }
      }

      /// <summary>
      /// Gets or sets the description of the item we've just picked up.
      /// </summary>
      public string PickUpText
      {
        get { return pickUpText; }
        set { pickUpText = value; }
      }

      /// <summary>
      /// Gets or sets the number of inventory
      /// slots required to take this item.
      /// </summary>
      /// <value>1</value>
      public int SlotsRequired
      {
        get { return slotsRequired; }
        set { slotsRequired = value; }
      }
    }
  }
