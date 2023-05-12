  using System.Collections.Generic; // List<T>

  namespace TheHyperionProject
  {
    /// <summary>
    ///   the room class
    ///
    ///   A class representing a room in the game :)
    /// </summary>
    class Room
    {
      #region Private Variables

      //Private variables
      private List<string> exits; /**< List of exits */
    
      //Private variables backing a C# property
      private string roomName;
      private string description;
      private List<Item> items;

      #endregion

      #region C# Properties
    
      /// <summary>
      /// Gets or sets the name of the room.
      /// </summary>
      /// <value>No default value.</value>
      public string RoomName
      {
        get { return roomName; }
        set { roomName = value; }
      }

      /// <summary>
      /// Room description
      /// </summary>
      public string Description
      {
        get { return description; }
        set { description = value; }
      }

      /// <summary>
      /// List of items in the room.
      /// </summary>
      public List<Item> Items
      {
        get { return items; }
        set { items = value; }
      }

      #endregion

      #region Public Member Functions
       
      public Room()
      {
        exits = new List<string>();
        items = new List<Item>();
      }

      /// <summary>
      ///   Tells us what that room looks like.
      ///
      ///   Provides us with a description of that room.
      /// </summary>
      public void Describe()
      {
        //TextBuffer.AddTextToBuffer(this.ProvideCoordinates());      
        TextBuffer.AddTextToBuffer(this.description);
        TextBuffer.AddTextToBuffer(this.ProvideItemList());
        TextBuffer.AddTextToBuffer(this.ProvideExitList());      
      }

      /// <summary>
      ///   Gives us a very brief "where you're at."
      ///
      ///   That's the name of the room.
      /// </summary>
      public void ShowRoomName()
      {
        TextBuffer.AddTextToBuffer(this.roomName);
      }

      /// <summary>
      ///   Tells us if it has an item.
      ///
      ///   We'll provide it with a textual name for the item.
      /// </summary>
      /// <param name="itemName">The name of the asked item</param>
      /// <returns>The asked item.
      public Item ProvideItem(string itemName)
      {
        foreach (Item item in this.items)
        {
          if (item.ItemName.ToLower() == itemName.ToLower())
            return item;
        }
        return null;
      }

      /// <summary>
      /// Adds new exit to the room.
      ///
      /// And does it on the fly.
      public void UnlockExit(string direction)
      {
        if (this.exits.IndexOf(direction) == -1)
          this.exits.Add(direction);
      }

      /// <summary>
      ///   Removes an exit.
      ///
      ///   When a door gets locked.
      /// </summary>
      public void LockExit(string direction)
      {
        if (this.exits.IndexOf(direction) != -1)
          this.exits.Remove(direction);
      }    

      /// <summary>
      ///   Tells us if we can exit in this direction.
      /// </summary>
      public bool TellIfExitAvailable(string direction)
      {
        foreach (string validExit in exits)
        {
          if (direction == validExit)
            return true;
        }
        return false;
      }
    
      #endregion

      #region Private Member Functions

      /// <summary>
      ///   Provides us with a list of items in this room.
      /// </summary>
      private string ProvideItemList()
      {
        string itemString = "";
        string message = "Items in Room:";
        string underline = "".PadLeft(message.Length, '-');

        if (this.items.Count > 0)
        {
          foreach (Item item in this.items)
          {
            itemString += "[" + item.ItemName + "]\n";
          }
        }
        else
        {
          itemString = "<none>";
        }
        return "\n" + message + "\n" + underline + "\n" + itemString;
      }

      /// <summary>
      ///   Provides a list of exits.
      ///
      ///   Gives us a list of all possible exits.
      /// </summary>
      private string ProvideExitList()
      {
        string exitString = "";
        string message = "Possible Directions:";
        string underline = "".PadLeft(message.Length, '-');

        if (this.exits.Count > 0)
        {
          foreach (string exitDirection in this.exits)
          {
            exitString += "[" + exitDirection + "]\n";
          }
        }
        else
        {
          exitString = "<none>";
        }
        return "\n" + message + "\n" + underline + "\n" + exitString;
      }    

      /// <summary>
      ///   Gives us the coordinates of that room.
      ///
      ///   Functionality for debugging.
      /// </summary>
      private string ProvideCoordinates()
      {
        for (int y = 0; y < Level.Rooms.GetLength(1); y++)
        {
          for (int x = 0; x < Level.Rooms.GetLength(0); x++)
          {
            if (this == Level.Rooms[x, y])
              return "[" + x.ToString() + "," + y.ToString() + "]";
          }
        }
        return "This room is not within the rooms grid.";
      }

      #endregion
    }
  }
