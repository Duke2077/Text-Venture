    ///   La classe principale.
    ///
    ///   Contient la fonction membre Main(), le point
    ///   d'entrée de l'application.
    /// </summary>
    class ClassePrincipale //is always public by default. Doesn't need to be static.
    {
      public static bool GameIsOn = true; 
    
      /// <summary>
      /// The entry point to the text venture game itself.
      /// </summary>
      static void Main() //Main can be private or public.
      {
        GameManager.ShowTitleScreen();

        Level.InitializeLevel();
        GameManager.StartGame();
      
        while (GameIsOn)
        {        
          Console.WriteLine("Please enter a command (or type \"exit\" to finish the game)");
          Console.Write("> ");
          CommandProcessor.ProcessCommand(Console.ReadLine());

          Console.WriteLine();
        }
        Console.Write("Game is over. Thank you for playing :)");
        Console.ReadKey(true); //The pressed key isn't displayed
        Console.Clear(); //Pour nettoyer l'écran en faisant un clear dans le terminal
      }
    }
  }
