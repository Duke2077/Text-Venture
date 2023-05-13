using System.Collections.Generic; // List<T>

namespace HeartbeatHunter
{
  /// <summary>
  ///   the location class
  ///
  ///   A class representing a location in the game :)
  /// </summary>
  class Location
  {
    public string Name { get; set; } /**< Location's name */
    public string Description { get; set; } /**< Location's description  */
    public LocationType LocationType { get; set; } /**< That location's type */
    public List<LocationElement> ExamineableElements { get; set; } /**< Examineable elements */
    public List<Item> Items { get; set; } /**< Items in room */

    //Private variables
    private List<Exit> exits; /**< List of exits */

      #region Public Member Functions

    public Location(string name, LocationType locationType, string description="")
    {
      Name = name;
      LocationType = locationType;
      Description = description;
      exits = new List<Exit>();
      ExamineableElements = new List<LocationElement>();
      Items = new List<Item>();
    }

    /// <summary>
    ///   Tells us what that location looks like.
    ///
    ///   Provides us with a description of that location.
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
      /// Provides us with a description of an examineable element in this location
      /// </summary>
      public void Describe(string examineableElement)
      {
        if (examineableElement == "")
        {
          if (ExamineableElements.Count == 0)
          {
            TextBuffer.AddTextToBuffer("There's nothing to examine in this place.");
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

        foreach (LocationElement element in ExamineableElements)
        {
          if (element.Name.ToLower() == examineableElement.ToLower())
          {
            TextBuffer.AddTextToBuffer(element.Description);
            return;
          }
        }
        TextBuffer.AddTextToBuffer($"There is no {examineableElement} at this location.");
      }

      /// <summary>
      ///   Gives us a very brief "where you're at."
      ///
      ///   That's the name of the location.
      /// </summary>
      public void ShowLocationName()
      {
        TextBuffer.AddTextToBuffer(this.Name);
      }

      /// <summary>
      ///   Provides a list of everything that can be examined at this location
      /// </summary>
      public void Examine()
      {
        if (ExamineableElements.Count == 0)
        {
          TextBuffer.AddTextToBuffer("There's nothing to examine at this location.");
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
      /// Adds new exit to the location.
      ///
      /// And does it on the fly.
      public void AddExit(Direction direction, Location destination)
      {
        foreach (Exit validExit in exits)
        {
          if (validExit.Direction == direction)
            return;
        }
        this.exits.Add(new Exit(direction, destination));
      }

      /// <summary>
      ///   Removes an exit.
      ///
      ///   When a door gets locked.
      /// </summary>
      public void RemoveExit(Direction direction)
      {
        foreach (Exit validExit in exits)
        {
          if (direction == validExit.Direction)
            this.exits.Remove(validExit);
        }
      }

      /// <summary>
      ///   Tells us if we can exit in this direction.
      /// </summary>
      public bool TellIfExitAvailable(Direction direction)
      {
        foreach (Exit validExit in exits)
        {
          if (direction == validExit.Direction)
            return true;
        }
        return false;
      }

      #endregion

      #region Private Member Functions

      /// <summary>
      /// Provides us with a list of examineable elements at this location
      /// </summary>
      private string ProvideExamineableElementList()
      {
        string elementString = "";
        string message = "Examineable Elements:";
        string underline = "".PadLeft(message.Length, '-');

        if (this.ExamineableElements.Count > 0)
        {
          foreach (LocationElement element in this.ExamineableElements)
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
    ///   Provides us with a list of items at this location
    /// </summary>
    private string ProvideItemList()
    {
      string itemString = "";
      string message = "Items at this Location:";
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
        foreach (Exit exitDirection in this.exits)
        {
          exitString += "[" + exitDirection.Direction + "]  ";
        }
      }
      else
      {
        exitString = "<none>";
      }
      return "\n" + message + "\n" + underline + "\n" + exitString;
    }

      #endregion
  }

  public enum LocationType
  {
    UrbanArea,
    Home,
    Shop,
    Restaurant
  }
}
