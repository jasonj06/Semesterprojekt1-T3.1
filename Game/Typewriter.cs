static class Typewriter
{
  private const int LetterDelayMs = 5;

  public static void WriteLine(string text)
  {
    if (Console.IsOutputRedirected)
    {
      Console.WriteLine(text);
      return;
    }

    foreach (var letter in text.EnumerateRunes())
    {
      Console.Write(letter.ToString());
      Thread.Sleep(LetterDelayMs);
    }

    Console.WriteLine();
  }

  public static void WriteLineColor(string color, string text)
  {
    if (Console.IsOutputRedirected)
    {
      Console.WriteLine(text);
      return;
    }

    var originalColor = Console.ForegroundColor;

    // Try to parse the color string into a ConsoleColor enum value
    if (Enum.TryParse<ConsoleColor>(color, ignoreCase: true, out ConsoleColor parsedColor))
    {
      Console.ForegroundColor = parsedColor;
    }

    foreach (var letter in text.EnumerateRunes())
    {
      Console.Write(letter.ToString());
      Thread.Sleep(LetterDelayMs);
    }

    Console.WriteLine();
    Console.ForegroundColor = originalColor;
  }
}
