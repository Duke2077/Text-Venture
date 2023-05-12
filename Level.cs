  namespace TheHyperionProject
  {
    /// <summary>
    ///   The Level class.
    ///
    ///   A class representing a level in the game :)
    /// </summary>
    static class Level
    {
      //Private variables backing a C# property
      private static Room[,] rooms;

      #region C# Properties
      /// <summary>
      /// Gets a two-dimensional array of Room objects.
      /// </summary>
      /// <value></value>
      public static Room[,] Rooms
      {
        get { return rooms; }
      }
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
        rooms = new Room[2, 2];

        Room room;
        Item item;

        /////////////////////////////////////////////////////
        //Create the RED ROOM
        room = new Room();

        //Assign this room to location 0, 0
        rooms[0, 0] = room;

        //Set up the room
        room.RoomName = "Red room";
        room.Description = "You have entered the red room. "
          + "There is a locked door to the south.";
        room.UnlockExit(Direction.East);

        //Create the BLUE BALL
        item = new Item();

        //Set up the item
        item.ItemName = "Blue ball";
        item.PickUpText = "You just picked up the blue ball.";

        //Add item to the current room
        room.Items.Add(item);

        /////////////////////////////////////////////////////
        //Create the BLUE ROOM
        room = new Room();

        //Assign this room to location 1, 0
        //We're now on the next column, same row
        rooms[1, 0] = room;

        //Set up the room
        room.RoomName = "Blue room";
        room.Description = "You have entered the blue room.";
        room.UnlockExit(Direction.West);			
        room.UnlockExit(Direction.South);

        //Create the ANVIL
        item = new Item();

        //Set up the item
        item.ItemName = "Anvil";
        item.PickUpText = "You picked up the anvil.";
        item.SlotsRequired = 6;

        //Add item to the current room
        room.Items.Add(item);

        //Create the GREEN BALL
        item = new Item();

        //Set up the item
        item.ItemName = "Green ball";
        item.PickUpText = "You just picked up the green ball.";

        //Add item to the current room
        room.Items.Add(item);

        //Create the KEY
        item = new Item();

        //Set up the item
        item.ItemName = "Key";
        item.PickUpText = "You just picked up the key.";

        //Add item to the current room
        room.Items.Add(item);

        /////////////////////////////////////////////////////
        //Create the YELLOW ROOM
        room = new Room();

        //Assign this room to location 1, 1
        rooms[1, 1] = room;

        //Set up the room
        room.RoomName = "Yellow room";
        room.Description = "You have entered the yellow room.";
        room.UnlockExit(Direction.North);			
        room.UnlockExit(Direction.West);

        //Create the RED BALL
        item = new Item();

        //Set up the item
        item.ItemName = "Red ball";
        item.PickUpText = "You just picked up the red ball.";

        //Add item to the current room
        room.Items.Add(item);

        /////////////////////////////////////////////////////
        //Create the GREEN ROOM
        room = new Room();

        //Assign this room to location 0, 1
        rooms[0, 1] = room;

        //Set up the room
        room.RoomName = "Green room";
        room.Description = "You have entered the green room. "
          + "There is a locked door to the north.";	
        room.UnlockExit(Direction.East);

        //Create the YELLOW BALL
        item = new Item();

        //Set up the item
        item.ItemName = "Yellow ball";
        item.PickUpText = "You just picked up the yellow ball.";

        //Add item to the current room
        room.Items.Add(item);


        //Place the player in the starting room
        Player.PosX = 0;
        Player.PosY = 0;
      }

      #endregion
    }
  }
