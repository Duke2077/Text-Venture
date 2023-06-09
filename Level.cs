
namespace HeartbeatHunter
{
  /// <summary>
  ///   The Level class.
  ///
  ///   A class representing a level in the game :)
  /// </summary>
  static class Level
  {
    //Private variables backing a C# property
    //private static Room[,] rooms;

      #region C# Properties
    /// <summary>
    /// Gets a two-dimensional array of Room objects.
    /// </summary>
    /// <value></value>
    //public static Room[,] Rooms
    //{
    //  get { return rooms; }
    //}
      #endregion

      #region Public Member Functions

    /// <summary>
    ///   Initializes the level.
    ///
    ///   The level-loading code is in BuildLevel.
    /// </summary>
    public static void InitializeLevel()
    {
      BuildLevel();
    }

      #endregion

  #region Private Member Functions

    /// <summary>
    ///   This loads a level after we've been playing
    ///   so we can play again.
    ///
    ///   Creates all the rooms in our level.
    ///   Creates all the items, places them in rooms within our
    ///   level and finally places the player physically in one
    ///   of those rooms.
    /// </summary>
    private static void BuildLevel()
    {
      //rooms = new Room[2, 2];

      //Room room;
      //ExamineableElement element;
      Place place;
      ExamineableElement element;
      Item item;

      /////////////////////////////////////////////////////
      //Create the PLACE
      Place house = new House("Hero's house", PlaceType.Home);
      Place bedroom = new Room("Hero's bedroom", PlaceType.Home);

      //Assign this room to location 0, 0
      //rooms[0, 0] = room;

      //Set up the room
      bedroom.Name = "Hero's bedroom";
      bedroom.Description = "You are in the hero's bedroom. "
        + "There is a locked door to the south.";
      bedroom.AddExit(Direction.East, house);

      //Create the Storage examineable element
      element = new ExamineableElement();
      element.Name = "Storage";
      element.Description = "It's the cardboard box sent from back home. It's full of clothes and daily necessities.";

      //Add examineable element to the current room
      bedroom.ExamineableElements.Add(element);

      //Create the Floor examineable element
      element = new ExamineableElement();
      element.Name = "Junk-littered Floor";
      element.Description = "There are all these unused household items lying here. It's not organized at all...";

      //Add examineable element to the current room
      bedroom.ExamineableElements.Add(element);

      //Create the Table examineable element
      element = new ExamineableElement();
      element.Name = "Messy Table";
      element.Description = "I guess I should clean the room while I'm organizing things...";

      //Add Table to the current room
      bedroom.ExamineableElements.Add(element);

      //Create the Desk
      element = new ExamineableElement();
      element.Name = "Cluttered Work Desk";
      element.Description = "It's a desk with a stack of books on top. No one can use this as a desk while it's like this...";

      //Add Table to the current room
      bedroom.ExamineableElements.Add(element);

      //Create the BLUE BALL
      item = new Item();

      //Set up the item
      item.Name = "blue ball";
      item.PickUpText = "It's a blue ball.";

      //Add item to the current room
      bedroom.Items.Add(item);

      // /////////////////////////////////////////////////////
      // //Create the BLUE ROOM
      // room = new Room();

      // //Assign this room to location 1, 0
      // //We're now on the next column, same row
      // rooms[1, 0] = room;

      // //Set up the room
      // room.Name = "Blue room";
      // room.Description = "You have entered the blue room.";
      // room.AddExit(Direction.West);
      // room.AddExit(Direction.South);

      // //Create the ANVIL
      // item = new Item();

      // //Set up the item
      // item.Name = "Anvil";
      // item.PickUpText = "You picked up the anvil.";
      // item.SlotsRequired = 6;

      // //Add item to the current room
      // room.Items.Add(item);

      // //Create the GREEN BALL
      // item = new Item();

      // //Set up the item
      // item.Name = "Green ball";
      // item.PickUpText = "You just picked up the green ball.";

      // //Add item to the current room
      // room.Items.Add(item);

      // //Create the KEY
      // item = new Item();

      // //Set up the item
      // item.Name = "Key";
      // item.PickUpText = "You just picked up the key.";

      // //Add item to the current room
      // room.Items.Add(item);

      // /////////////////////////////////////////////////////
      // //Create the YELLOW ROOM
      // room = new Room();

      // //Assign this room to location 1, 1
      // rooms[1, 1] = room;

      // //Set up the room
      // room.Name = "Yellow room";
      // room.Description = "You have entered the yellow room.";
      // room.AddExit(Direction.North);
      // room.AddExit(Direction.West);

      // //Create the RED BALL
      // item = new Item();

      // //Set up the item
      // item.Name = "Red ball";
      // item.PickUpText = "You just picked up the red ball.";

      // //Add item to the current room
      // room.Items.Add(item);

      // /////////////////////////////////////////////////////
      // //Create the GREEN ROOM
      // room = new Room();

      // //Assign this room to location 0, 1
      // rooms[0, 1] = room;

      //   //Set up the room
      //   room.Name = "Green room";
      //   room.Description = "You have entered the green room. "
      //     + "There is a locked door to the north.";
      //   room.AddExit(Direction.East);

      //   //Create the YELLOW BALL
      //   item = new Item();

      //   //Set up the item
      //   item.Name = "Yellow ball";
      //   item.PickUpText = "You just picked up the yellow ball.";

      //   //Add item to the current room
      //   room.Items.Add(item);


        //Place the player in the starting room
      Player.CurrentPlace = bedroom;
        //Player.PosX = 0;
        //Player.PosY = 0;
    }

      #endregion
  }
}
