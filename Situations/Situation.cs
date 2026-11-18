static class Situation
{
  public static void Explosion()
  {
    Typewriter.WriteLine("En dyb rumlen bryder gennem maskinernes støj.");
    Typewriter.WriteLine("Gulvet begynder at vibrere under dine fødder.");
    Pause(500);
    Console.WriteLine();

    // Restore the normal text color after the explosion.
    ConsoleColor previousColor = Console.ForegroundColor;
    try
    {
      if (!Console.IsOutputRedirected)
      {
        Console.ForegroundColor = ConsoleColor.Red;
      }

      Typewriter.WriteLine("       KRRRRRRR...");
      Pause(300);
      Typewriter.WriteLine("   KRRRRRRRRRR...");
      Pause(500);
      Console.WriteLine();
      Typewriter.WriteLine("          B R A A A G !");
      Pause(400);
      Console.WriteLine();
      Typewriter.WriteLine("             EKSPLOSION!");
      Pause(600);
      Console.WriteLine();
    }
    finally
    {
      if (!Console.IsOutputRedirected)
      {
        Console.ForegroundColor = previousColor;
      }
    }

    Typewriter.WriteLine("En voldsom trykbølge slår gennem fabrikken.");
    Typewriter.WriteLine("Gulvet gynger. Vinduer klirrer, og støv vælter");
    Typewriter.WriteLine("ned fra loftet omkring dig.");
    Console.WriteLine();
    Typewriter.WriteLine("Lyset går ud.");
    Pause(1000);
    Console.WriteLine();
    Typewriter.WriteLine("Et øjeblik er alt mørkt.");
    Pause(1000);
    Console.WriteLine();
    Typewriter.WriteLine("Så tænder det røde nødlys.");
    Typewriter.WriteLine("Evakueringsalarmen skærer gennem luften.");
    Console.WriteLine();
    Typewriter.WriteLine("Du skal finde sikkert ud af bygningen.");
    Pause(700);
    Console.WriteLine();
  }

  private static void Pause(int milliseconds)
  {
    if (!Console.IsOutputRedirected)
    {
      Thread.Sleep(milliseconds);
    }
  }
}
