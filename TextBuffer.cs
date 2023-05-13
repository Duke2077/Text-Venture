
namespace HeartbeatHunter
{
  /// <summary>
  ///   the text buffer class
  ///
  ///   Contains text.
  /// </summary>
  static class TextBuffer
  {
    private static string outputBuffer; /**< the text content */


    /// <summary>
    ///   Adds text to the buffer.
    /// </summary>
    public static void AddTextToBuffer(string text)
    {
      outputBuffer += text + "\n";
    }

    /// <summary>
    ///   Displays the content of the buffer.
    ///
    ///   Displays to the screen.
    /// </summary>
    public static void Display()
    {
      Console.Clear();
      Console.Write(TextUtilities.WordWrap(outputBuffer, Console.WindowWidth));
      //Console.WriteLine("Please enter a command (or type \"exit\" to finish the game)");
      //Console.Write("huy@DRAGOON:~/The Hyperion Project$ ");

      outputBuffer = "";
    }
  }
}

