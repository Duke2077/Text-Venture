using System.Collections.Generic; // List<T>

namespace HeartbeatHunter
{
  /// <summary>
  ///   the Place class
  ///
  ///   A class representing a place in the game :)
  /// </summary>
  abstract class Place
  {
    public string Name { get; set; } /**< The name of the place */
    public string Description { get; set; } /**< Place's description  */
    public PlaceType PlaceType { get; set; } /**< The type of place */
    public List<ExamineableElement> ExamineableElements { get; set; } = new List<ExamineableElement>(); /**< Examineable elements */
    public List<Item> Items { get; set; } = new List<Item>(); /**< Items in room */
    public List<Exit> Exits { get; set; } = new List<Exit>();

      #region Public Member Functions

    public Place(string name, PlaceType placeType, string description="")
    {
      Name = name;
      PlaceType = placeType;
      Description = description;
    }

    /// <summary>
    ///   Tells us what that place looks like.
    ///
    ///   Provides us with a description of that place.
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
    /// Provides us with a description of an examineable element in this place
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

      foreach (ExamineableElement element in ExamineableElements)
      {
        if (element.Name.ToLower() == examineableElement.ToLower())
        {
          TextBuffer.AddTextToBuffer(element.Description);
          return;
        }
      }
      TextBuffer.AddTextToBuffer($"There is no {examineableElement} in this place.");
    }

    /// <summary>
    ///   Gives us a very brief "where you're at."
    ///
    ///   That's the name of the place.
    /// </summary>
    public void ShowPlaceName()
    {
      TextBuffer.AddTextToBuffer(this.Name);
    }

    /// <summary>
    ///   Provides a list of everything that can be examined in this place
    /// </summary>
    public void Examine()
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
    /// Adds a new exit to this place.
    ///
    /// And does it on the fly.
    public void AddExit(Direction direction, Place destination)
    {
      Exit exit = Exits.Find(e => e.Direction == direction);
      if (exit != null)
      {
          Console.WriteLine($"There is already an exit to the {direction}.");
          return;
      }

      exit = new Exit(direction, destination);
      Exits.Add(exit);
      exit = new Exit(direction.Opposite(), this);
      destination.Exits.Add(exit);
    }

    /// <summary>
    ///   Removes an exit.
    ///
    ///   When a door gets locked.
    /// </summary>
    public void RemoveExit(Direction direction)
    {
      Exit exit = Exits.Find(e => e.Direction == direction);

      if (exit == null)
      {
        Console.WriteLine($"There is no exit to the {direction}.");
        return;
      }

      Exits.Remove(exit);
      Console.WriteLine($"Exit to the {direction} removed.");
    }

    /// <summary>
    ///   Tells us if we can exit in this direction.
    /// </summary>
    public bool IsExitAvailableInDirection(Direction direction)
    {
      foreach (Exit exit in Exits)
      {
        if (exit.Direction == direction)
          return true;
      }
      return false;
    }

      #endregion

      #region Private Member Functions

    /// <summary>
    /// Provides us with a list of examineable elements in this place
    /// </summary>
    private string ProvideExamineableElementList()
    {
      string elementString = "";
      string message = "Examineable Elements:";
      string underline = "".PadLeft(message.Length, '-');

      if (this.ExamineableElements.Count > 0)
      {
        foreach (ExamineableElement element in this.ExamineableElements)
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
    ///   Provides us with a list of items in this place
    /// </summary>
    private string ProvideItemList()
    {
      string itemString = "";
      string message = "Items in this place:";
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

      if (Exits.Count > 0)
      {
        foreach (Exit exit in Exits)
        {
          exitString += "[" + exit.Direction + "]  ";
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

  public enum PlaceType
  {
    UrbanArea,
    Home,
    Shop,
    Restaurant
  }
}
