using System.Collections.Generic; //List

namespace HeartbeatHunter
{
  /// <summary>
  ///   the Player class :)
  /// </summary>
  static class Player
  {
      #region Private Variables

    public static Location CurrentLocation { get; set; }

    //Private fields / Private variables
    private static List<Item> inventoryItems;

    //Private fields backing a property
    private static int posX;
    private static int posY;
    private static int inventoryCapacity = 6;
    private static int playedMoves = 0;
      #endregion
    
      #region C# Properties

    /// <summary>
    /// Gets or sets the player's position in X.
    /// </summary>
    public static int PosX
    {
      get { return posX; }
      set { posX = value; }
    }

    /// <summary>
    /// Gets or sets the player's position in Y.
    /// </summary>
    public static int PosY
      {
        get { return posY; }
        set { posY = value; }
      }

      /// <summary>
      /// Gets or sets The player's maximum
      /// number of moves that are possible.
      /// </summary>
      public static int PlayedMoves
      {
        get { return playedMoves; }
        set { playedMoves = value; }
      }

      /// <summary>
      /// Gets or sets the player's inventory total slot capacity.
      /// </summary>
      /// <value>6</value>
      public static int InventoryCapacity
      {
        get { return inventoryCapacity; }
        set { inventoryCapacity = value; }
      }

      /// <summary>
      ///   Performs the slot calculation 
      /// </summary>
      public static int InventorySlotsInUse
      {
        get
        {
          int slotsInUse = 0;
          foreach (Item item in inventoryItems)
          {
            slotsInUse += item.SlotsRequired;          
          }
          return slotsInUse;
        }
      }

      #endregion

    static Player()
    {
      inventoryItems = new List<Item>();
    }
    
      #region Public Member Functions
    
    /// <summary>
    ///   Moves in specified direction if possible.
    ///
    ///   Asks the room if we can move in that direction.
    ///   If yes, moves in that specified direction.
    /// </summary>
    /// <param name="direction">direction to move towards</param>
    /// <returns>bool
    public static void Move(Direction direction)
    {
      Location currentLocation = Player.GetCurrentLocation();

      if (!currentLocation.TellIfExitAvailable(direction))
      {
        TextBuffer.AddTextToBuffer("It doesn't look like we can " +
                                   "move in that direction.");
        return;
      }

      Player.playedMoves++;

      switch (direction)
      {
        case (Direction)Enum.Parse(typeof(Direction), Direction.North): //"north"
          PosY--;
          break;
        //case Direction.South:
         // PosY++;
         // break;
        //case Direction.East:
         // PosX++;
          //break;
        //case Direction.West:
         // PosX--;
          //break;
      }
      Player.GetCurrentLocation().Describe();
    }

    /// <summary>
    ///   Picks up a specified item.
    ///
    ///   Look at the room we're in. Does this item exist?
    ///   If so, let's take the item out of the room and place
    ///   it in our inventory.
    /// </summary>
    /// <param name="itemName">name of the item to pick up</param>
    /// <returns>The actual item.
    public static void PickUpItem(string itemName)
    {
      Location location = Player.GetCurrentLocation();
      Item item = location.ProvideItem(itemName);

      if (item != null)
      {
          if (Player.InventorySlotsInUse + item.SlotsRequired 
              > Player.InventoryCapacity)
          {
            TextBuffer.AddTextToBuffer("Not enough room in inventory. " +
                                       "You need to free some space or " +
                                       "increase your inventory capacity before " +
                                       "you can pick up this item.");
            return;
          }

          location.Items.Remove(item);
          inventoryItems.Add(item); //Player.inventoryItems.Add(item);
          TextBuffer.AddTextToBuffer(item.PickUpText);

        } else
          TextBuffer.AddTextToBuffer("There is no " + itemName + " in this location.");
      }
    
      /// <summary>
      ///   Drops a specified item.
      ///
      ///   Take the item out of the player's inventory list and
      ///   drop it into the room's item list.
      /// </summary>
      /// <param name="itemName">the item's textual name</param>
      public static void DropItem(string itemName)
      {
        Location location = Player.GetCurrentLocation();
        Item item = Player.GetInventoryItem(itemName);

        if (item != null)
        {
          inventoryItems.Remove(item); //Player.inventoryItems.Remove (item);
          location.Items.Add(item);
          TextBuffer.AddTextToBuffer("The " + itemName
                                     + " has been dropped into this location.");
        } else
          TextBuffer.AddTextToBuffer("There is no " + itemName
                                     + " in your inventory.");
      }    

      /// <summary>
      ///   Shows the inventory.
      ///
      ///   Also shows how many slots we have available.
      /// </summary>
      public static void DisplayInventory()
      {
        string message = "Your inventory contains:";
        string underline = "";
        underline = underline.PadLeft (message.Length, '-');
        string itemString = "";

        if (inventoryItems.Count > 0)
        {
          foreach (Item item in inventoryItems)
          {
            itemString += "\n[" + item.Name + "] - Slots used: "
              + item.SlotsRequired.ToString();
          }
        } else
          itemString = "<no items>";

        itemString += "\n\nInventory slots in use: "
          + Player.InventorySlotsInUse + " / "
          + Player.InventoryCapacity;
    
        TextBuffer.AddTextToBuffer(message + "\n" + underline + "\n" + itemString);
      }

    /// <summary>
    ///   Gives us the name of the room we're in.
    ///
    ///   Provides us with the room we're in.
    /// </summary>
    public static Location GetCurrentLocation()
    {
      return Player.CurrentLocation;
        //return Level.Rooms[PosX, PosY];
    }

    /// <summary>
    ///   Takes in a textual name of an item and sees
    ///   if it exists in our inventory list.
    ///
    ///   If it does, this returns the actual item.
    /// </summary>
    /// <param name="itemName">item's name</param>
    /// <returns>The actual item.
    public static Item GetInventoryItem(string itemName)
    {
      foreach (Item item in inventoryItems)
      {
        if (item.Name.ToLower() == itemName.ToLower())
        {
          return item;
        }
      }
      return null;
    }
      #endregion
  }
}
