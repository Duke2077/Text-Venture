
namespace HeartbeatHunter
{
  /// <summary>
  ///   the Text Utilities class
  ///
  ///   Contains the functionality for word wrapping text.
  /// </summary>
  static class TextUtilities
  {
    /// <summary>
    ///   Extracts a command from a line of text.
    /// </summary>
    public static string ExtractCommand(string line)
    {
      //remove all heading and trailing whitespace characters
      //from the current String object, then convert to lowercase
      line = line.Trim().ToLower();
      int spaceIndex = line.IndexOf(' ');

      if (spaceIndex == -1)
        return line;
      else
      {
        //checking to see if the player used the "pick up" command
        if (line.Substring(0, spaceIndex + 3) == "pick up")
          return "pick up";
        else
          //return a substring starting from the beginning
          //and with a length of spaceIndex characters
          return line.Substring(0, spaceIndex);
      }
    }

    /// <summary>
    ///   Extracts the arguments from a line of text.
    /// </summary>
    public static string ExtractArguments(string line)
    {
      line = line.Trim(); //suppression des espaces, lowercase
      int spaceIndex = line.IndexOf(' ');

      if (spaceIndex == -1)
        return "";
      else
      {
        //checking to see if the player used the "pick up" command
        if (line.Substring(0, spaceIndex + 3).ToLower() == "pick up")
          return line.Substring(spaceIndex + 4, line.Length - 8);
        else
        {
          //Take a substring from line, starting from after the first space
          //Remove heading spaces before returning this substring
          string arguments = line.Substring(spaceIndex + 1, line.Length - spaceIndex - 1).Trim();
          return arguments;
        }
      }
    }

    /// <summary>
    ///   Starts a new line before any word gets the
    ///   chance to get broke at the end of the console.
    ///
    ///   ... and start on the next line.
    /// </summary>
    public static string WordWrap(string text,
                                  int bufferWidth)
    {
      string result = "";
      string[] lines = text.Split('\n');

      foreach (string line in lines)
      {
        int lineLength = 0;
        string[] words = line.Split(' ');

        foreach (string word in words)
        {
          if (word.Length + lineLength >= bufferWidth - 1)
          {
            result += "\n";
            lineLength = 0;
          }
          result += word + " ";
          lineLength += word.Length + 1;
        }
        result += "\n";
      }
      return result;
    }
  }
}

