  namespace TheHyperionProject
  {
    /// <summary>
    ///   the command processor class
    ///
    ///   Processes the commands that the gamer inputs.
    /// </summary>
    static class CommandProcessor
    {
      /// <summary>
      ///   Processes input command.
      ///
      ///   Takes in a line of text that was entered, breaks that
      ///   up, divide it in two pieces: a command piece and an
      ///   argument piece. See if this is a valid command. If
      ///   it is, then we do something based on that command,
      ///   possibly also using arguments along with it.
      /// </summary>
      /// <param name="line">line of text to process</param>
      /// <returns>void
      /// </summary>
      public static void ProcessCommand(string line)
      {
        string command = TextUtilities.ExtractCommand(line);
        string arguments = TextUtilities.ExtractArguments(line);

        if (Direction.IsValidDirection(command))
        {
          Player.Move(command);
        }
        else
        {
          switch (command)
          {
            case "exit":
              ClassePrincipale.GameIsOn = false;
              return;
            case "help":
              ShowHelp();
              break;
            case "move":
              Player.Move(arguments);
              break;
            case "look":
              Player.GetCurrentRoom().Describe();
              break;
            case "pick up":
              Player.PickUpItem(arguments);
              break;
            case "drop":
              Player.DropItem(arguments);
              break;
            case "inventory":
              Player.DisplayInventory();
              break;
            case "whereami":
              Player.GetCurrentRoom().ShowRoomName();
              break;
            default:
              TextBuffer.AddTextToBuffer("Unrecognized command.");          
              break;
          }
        }
        // This is the ideal place to check our rules,
        // right after we did an action.
        GameManager.ApplyRules();

        //In case the game was won or lost, we want to exit
        //the game now, without displaying what was in the text
        //buffer
        if (!ClassePrincipale.GameIsOn)
        {
          return;
        }

        TextBuffer.Display();
      }
    
      /// <summary>
      ///   Displays help.
      ///
      ///   Shows a help screen with available commands.
      /// </summary>
      public static void ShowHelp()
      {
        TextBuffer.AddTextToBuffer("Available Commands:");
        TextBuffer.AddTextToBuffer("-------------------");
        TextBuffer.AddTextToBuffer("help");
        TextBuffer.AddTextToBuffer("exit");
        TextBuffer.AddTextToBuffer("move [north, south, east, west]");
        TextBuffer.AddTextToBuffer("look");
        TextBuffer.AddTextToBuffer("pick up");
        TextBuffer.AddTextToBuffer("drop");
        TextBuffer.AddTextToBuffer("inventory");
        TextBuffer.AddTextToBuffer("whereami");
      }    
    }
  }
