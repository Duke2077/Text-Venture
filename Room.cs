
using System.Collections.Generic; // List<T>

  namespace HeartbeatHunter
  {
    /// <summary>
    ///   the room class
    ///
    ///   A class representing a room in the game :)
    /// </summary>
    class Room
    {
      public string Name { get; set; } /**< Room name */
      public string Description { get; set; } /**< Room description  */
      public List<RoomElement> ExamineableElements { get; set; } /**< Examineable elements */
      public List<Item> Items { get; set; } /**< Items in room */

      //Private variables
      private List<string> exits; /**< List of exits */

      #region Public Member Functions

      public Room()
      {
        exits = new List<string>();
        ExamineableElements = new List<RoomElement>();
        Items = new List<Item>();
      }

      /// <summary>
      ///   Tells us what that room looks like.
      ///
      ///   Provides us with a description of that room
      /// </summary>
      public void Describe()
      {
        //TextBuffer.AddTextToBuffer(this.ProvideCoordinates());
        TextBuffer.AddTextToBuffer(this.Description);
        TextBuffer.AddTextToBuffer(this.ProvideExamineableElementList());
        TextBuffer.AddTextToBuffer(this.ProvideItemList());
        TextBuffer.AddTextToBuffer(this.ProvideExitList());
      }

      /// <summary>
      /// Provides us with a description of an examineable element in this room
      /// </summary>
      public void Describe(string examineableElement)
      {
        if (examineableElement == "")
        {
          if (ExamineableElements.Count == 0)
          {
            TextBuffer.AddTextToBuffer("There's nothing to examine in this room.");
            return;
          }

          TextBuffer.AddTextToBuffer("What do you want to examine?");
          for (int i = 0; i < ExamineableElements.Count; i++)
          {
            TextBuffer.AddTextToBuffer($"{i + 1} - {ExamineableElements[i].Name}");
          }
          TextBuffer.Display();

          int choice;
          Console.Write("> ");
          if (!Int32.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > ExamineableElements.Count)
          {
            TextBuffer.AddTextToBuffer("Invalid choice.");
            return;
          }
          TextBuffer.AddTextToBuffer(ExamineableElements[choice - 1].Description);
          return;
        } //Si le joueur a seulement tapé "examine"

        foreach (RoomElement element in ExamineableElements)
        {
          if (element.Name.ToLower() == examineableElement.ToLower())
          {
            TextBuffer.AddTextToBuffer(element.Description);
            return;
          }
        }
        TextBuffer.AddTextToBuffer($"There is no {examineableElement} in this room.");
      }

      /// <summary>
      ///   Gives us a very brief "where you're at."
      ///
      ///   That's the name of the room.
      /// </summary>
      public void ShowRoomName()
      {
        TextBuffer.AddTextToBuffer(this.Name);
      }

      /// <summary>
      ///   Provides a list of everything that can be examined in this room
      /// </summary>
      public void Examine()
      {
        if (ExamineableElements.Count == 0)
        {
          TextBuffer.AddTextToBuffer("There's nothing to examine in this room.");
          return;
        }

        TextBuffer.AddTextToBuffer("What do you want to examine?");
        for (int i = 0; i < ExamineableElements.Count; i++)
        {
          TextBuffer.AddTextToBuffer($"{i + 1} - {ExamineableElements[i].Name}");
        }
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
        foreach (Item item in this.Items)
        {
          if (item.Name.ToLower() == itemName.ToLower())
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
      /// Provides us with a list of examineable elements in this room
      /// </summary>
      private string ProvideExamineableElementList()
      {
        string elementString = "";
        string message = "Examineable Elements:";
        string underline = "".PadLeft(message.Length, '-');

        if (this.ExamineableElements.Count > 0)
        {
          foreach (RoomElement element in this.ExamineableElements)
          {
            elementString += "[" + element.Name + "] ";
          }
        }
        else
        {
          elementString = "<none>";
        }
        return "\n" + message + "\n" + underline + "\n" + elementString;
      }

      /// <summary>
      ///   Provides us with a list of items in this room
      /// </summary>
      private string ProvideItemList()
      {
        string itemString = "";
        string message = "Items in Room:";
        string underline = "".PadLeft(message.Length, '-');

        if (this.Items.Count > 0)
        {
          foreach (Item item in this.Items)
          {
            itemString += "[" + item.Name + "]  ";
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
            exitString += "[" + exitDirection + "]  ";
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

