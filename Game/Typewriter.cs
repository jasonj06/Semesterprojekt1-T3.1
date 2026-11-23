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

  public static void WriteLineColor(ConsoleColor color, string text)
  {
    if (Console.IsOutputRedirected)
    {
      Console.WriteLine(text);
      return;
    }

    var originalColor = Console.ForegroundColor;
    Console.ForegroundColor = color;

    foreach (var letter in text.EnumerateRunes())
    {
      Console.Write(letter.ToString());
      Thread.Sleep(LetterDelayMs);
    }

    Console.WriteLine();
    Console.ForegroundColor = originalColor;
  }
}
