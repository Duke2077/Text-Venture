
  //using System; //without this using line, it still works
                  //within and outside of VSCode

  namespace HeartbeatHunter
  {
    /// <summary>
    ///   The GameManager class.
    ///
    ///   Manages the game.
    /// </summary>
    static class GameManager
    {
      #region Public Member Functions

      /// <summary>
      ///   Displays a title screen.
      ///
      ///   Displays introductory information about the game.
      /// </summary>
      public static void ShowTitleScreen()
      {
        Console.Clear();
        Console.WriteLine(TextUtilities.WordWrap("*** HEARTBEAT HUNTER *** " +
                                                 "A Text-based Adventure Game.\n",
                                                 Console.WindowWidth));

        Console.WriteLine(TextUtilities.WordWrap("Welcome to Heartbeat Hunter.",
                                                 Console.WindowWidth));

        Console.WriteLine ("Info: You may type 'help' at any " +
                           "time\nto see a list of available commands.");
        Console.Write ("\nPress a key to begin");

        Console.CursorVisible = false;
        Console.ReadKey();
        Console.CursorVisible = true;
        Console.Clear();
      }

      /// <summary>
      ///   Displays the level.
      ///
      ///   Objects have been placed inside of rooms. Rooms
      ///   have been placed inside the level. And now it's time
      ///   to start the game. This kicks off the display of the
      ///   level.
      /// </summary>
      public static void StartGame()
      {
        Player.GetCurrentRoom().Describe();
        TextBuffer.Display();
      }

      /// <summary>
      ///   Ends the game.
      ///
      ///   Marks the program as ready to quit and then show
      ///   the final ending message. Will then prevent any
      ///   further input.
      /// </summary>
      public static void EndGame(string endingText)
      {
        ClassePrincipale.GameIsOn = false;

        Console.Clear();
        Console.WriteLine(TextUtilities.WordWrap(endingText,
                                                 Console.WindowWidth));
        Console.WriteLine("\nYou may now close this window.");
        Console.CursorVisible = false;

        Console.ReadKey (true);
      }

      /// <summary>
      ///   Applies our game's rules.
      ///
      ///   Sees if the player, objects and rooms are arranged
      ///   in a way that triggers something special like an
      ///   ending or loss of life.
      /// </summary>
      public static void ApplyRules()
      {
        if ((Level.Rooms[0, 0].ProvideItem("Red Ball") != null) &&
          (Level.Rooms[1, 0].ProvideItem("Blue Ball") != null) &&
            (Level.Rooms[1, 1].ProvideItem("Yellow Ball") != null) &&
              (Level.Rooms[0, 1].ProvideItem("Green Ball") != null))
        {
          EndGame ("Well done! You win!");
        }

        if (Player.GetInventoryItem("Key") != null)
        {
          Level.Rooms[0, 0].UnlockExit(Direction.South); //unlock door to the south in red room
          Level.Rooms[0, 0].Description = "You have entered the red room.";

          Level.Rooms[0, 1].UnlockExit(Direction.North); //unlock door to the north in green room
          Level.Rooms[0, 1].Description = "You have entered the green room.";
        }

        if (Player.PlayedMoves > 10)
        {
          EndGame("You have used your 10 possible moves. Game is now over.");
        }
      }

      #endregion
    }
  }

