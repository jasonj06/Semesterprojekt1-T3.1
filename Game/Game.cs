/* Main class for launching the game
 */

class Game
{
  // Creates the game world, including its rooms and connections.
  static World world = new World();
  // Tracks the current room and whether the game has ended, starting in the entry room.
  static Context context = new Context(world.GetEntry());

  public static Inventory inventory = new Inventory();

  static BrandSpredning brandSpredning = new BrandSpredning();

  static void Main(string[] args)
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;
    Typewriter.WriteLine("Velkommen til vores evakuerings spil omkring kemikalie sikkerhed, tryk enter for at forsætte");
    if (Console.ReadLine() == null)
    {
      return;
    }

    if (!Console.IsOutputRedirected)
    {
      Console.Clear();
    }

    Typewriter.WriteLine("Du starter din dag på arbejde ved Bland & Håb A/S som nyanset medarbejder, du befinder dig i receptionen.");
    Situation.Explosion();
    Console.WriteLine("Tryk Enter for at fortsætte.");
    if (Console.ReadLine() == null)
    {
      return;
    }

    if (!Console.IsOutputRedirected)
    {
      Console.Clear();
    }

    Item brandSlukker = new Item("1", "Brandslukker", "Bruges til at slukke mindre brande", "Sikkerhedsudstyr", true);

    Item førstehjælpskasse = new Item("3", "Førstehjælpskasse", "Bruges til at behandle skader og forbrændinger", "Førstehjælp", true);

    Item evak = new Item("4", "Evakueringsplan", "Låser minimappet op, når du bruger den", "Dokument", true);

    Item brandØkse = new Item("5", "Brandøkse", "Bruges til at åbne bestemte blokerede passager", "Værktøj", false);
    //Nye og ændrede items

    // Displays the starting room's welcome message.
    context.ShowCurrentRoom();
    ConsoleColor previousColor = Console.ForegroundColor;
    if (!Console.IsOutputRedirected)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Typewriter.WriteLine("Skriv søg for at undersøge rummet og finde evakueringsplanen.");
    if (!Console.IsOutputRedirected)
    {
      Console.ForegroundColor = previousColor;
    }

//Tilføjer en turn til brandspredning og tjekker hvad den er.
    context.Timer.TurnChanged += (turn) =>
    {
      if (brandSpredning.CheckTurn(turn))
      {
        context.MakeDone();
      }
    };



    // Keeps asking for commands until the context marks the game as finished.
    while (context.IsDone() == false)
    {
      // Shows a prompt and reads a line typed by the player.
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line == null) continue;

      string[] elements = line.Split(" ");
      string command = elements[0];
      // Keep the whole room or item name, including any spaces.
      string target = string.Join(" ", GetParameters(elements)).Trim(' ', '"');

      // Match commands even when the player uses capital letters.
      switch (command.ToLowerInvariant())
      {
        case "stop":
        case "exit":
        case "quit":
        case "bye":
          context.MakeDone();
          break;
        case "gå":
          if (target.Length == 0)
          {
            Typewriter.WriteLine("Skriv gå efterfulgt af rummets navn.");
            break;
          }
          context.Transition(target);
          if (context.HasWon() && !context.IsDone())
          {
            if (Console.ReadLine() == null)
            {
              context.MakeDone();
              break;
            }
            context.Transition("Samlingspunkt");
          }
          break;
        case "søg":
        case "sog":
          context.GetCurrent().Search();
          break;
        case "tag":
          if (target.Length == 0)
          {
            Typewriter.WriteLine("Skriv tag efterfulgt af genstandens navn.");
            break;
          }
          context.GetCurrent().TakeItem(target, inventory);
          break;
        case "brug":
          UseItem(target);
          break;
        case "inventory":
        case "inv":
          ShowInventory();
          break;
        case "info":
        case "help":
          ShowCommands();
          break;
        default:
          // Handles input that does not match any of the commands above.
          Typewriter.WriteLine("Dette er ikke en mulig kommando '" + command);
          break;
      }
    }
    if (context.HasWon()) {
      Console.WriteLine("Tak fordi du spillede!");
    } else {
      Typewriter.WriteLine("Game Over 😥");
    }
  }

  // Info and help share this command list.
  private static void ShowCommands()
  {
    Console.WriteLine("--- Kommandoer ---");
    Console.WriteLine(" - gå <rumnavn>  Gå til et rum");
    Console.WriteLine(" - søg  Søg efter genstande i rummet");
    Console.WriteLine(" - tag <genstand>  Saml en genstand op");
    Console.WriteLine(" - brug <genstand>  Brug en genstand fra din inventory");
    Console.WriteLine(" - inventory, inv  Vis dine genstande");
    Console.WriteLine(" - info, help  Vis alle kommandoer");
    Console.WriteLine(" - stop, exit, quit, bye  Afslut spillet");
  }

  private static void UseItem(string itemName)
  {
    if (itemName.Length == 0)
    {
      Typewriter.WriteLine("Skriv brug efterfulgt af genstandens navn.");
      return;
    }

    Item? item = inventory.FindItem(itemName);
    if (item == null)
    {
      Typewriter.WriteLine("Du har ikke " + itemName + " i din inventory.");
      return;
    }

    if (item.GetId() == "4")
    {
      inventory.RemoveItem(item);
      context.UnlockMinimap();

      if (!Console.IsOutputRedirected)
      {
        Console.Clear();
      }

      //Melanie tutorial message
      Console.WriteLine("===== TUTORIAL GENNEMFØRT =====");
      Console.WriteLine();
      Console.WriteLine("Du har nu gennemgået virksomhedens sikkerhedsprocedurer.");
      Console.WriteLine("Du har lært at søge efter, finde og bruge genstande.");
      Console.WriteLine();
      Console.WriteLine("Du har nu adgang til bygningens minimap,");
      Console.WriteLine("som kan hjælpe dig med at navigere under evakueringen.");
      Console.WriteLine();
      Console.WriteLine("----- KOMMANDOER -----");
      Console.WriteLine("søg             - Undersøg rummet for genstande.");
      Console.WriteLine("inv             - Se genstandene i din inventory.");
      Console.WriteLine("brug [genstand] - Brug en genstand fra din inventory.");
      Console.WriteLine("gå [rum]        - Bevæg dig til et tilstødende rum.");
      Console.WriteLine("help            - Se en liste over tilgængelige kommandoer.");
      Console.WriteLine();
      Console.WriteLine("Du er nu klar til at bevæge dig rundt i bygningen.");
      Console.WriteLine("Husk, at dine beslutninger kan have konsekvenser.");
      Console.WriteLine();
      Console.WriteLine("Minimap er nu låst op!");
      Console.WriteLine("===============================");
      Console.WriteLine();
      
      Console.WriteLine("Tryk Enter for at vende tilbage til rummet.");
      if (Console.ReadLine() == null)
      {
        context.MakeDone();
        return;
      }

      if (!Console.IsOutputRedirected)
      {
        Console.Clear();
      }
      context.ShowCurrentRoom();
      return;
    }

    switch (item.GetItemType())
    {
      case "Dokument":
        Typewriter.WriteLine(item.Read());
        break;
        case "Sikkerhedsudstyr":
        if(context.GetCurrent().GetName().ToLower() == "førstehjælpsrum")
        {
            context.IsCanteenFireOut = true;
            Typewriter.WriteLine("Du slukkede branden i kantinen.");
        }
        else
        {
            Typewriter.WriteLine("Du kan ikke bruge " + item.GetName() + " her.");
        }
        break;
        case "Værktøj":
        if(context.GetCurrent().GetName().ToLower() == "kontor")
        {
            context.IsExitUnblocked = true;
            Typewriter.WriteLine("Du swinger brandøksen og smadre blokeringen til udgangen");
        }
        else
        {
            Typewriter.WriteLine("Du kan ikke bruge " + item.GetName() + " her.");
        }
        break;
      default:
        Typewriter.WriteLine("Du kan ikke bruge " + item.GetName() + " her.");
        break;
    }
  }

  private static void ShowInventory()
  {
    List<Item> items = inventory.GetItems();
    // Show at least four slots, with extra lines for any additional items.
    int numberOfSlots = Math.Max(4, items.Count);

    Console.WriteLine("--- Inventory ---");
    for (int i = 0; i < numberOfSlots; i++)
    {
      string slot = (i + 1) + ".";
      if (i < items.Count)
      {
        slot += " " + items[i].GetName();
      }
      Console.WriteLine(slot);
    }

    if (inventory.FindItem("Evakueringsplan") != null)
    {
      Typewriter.WriteLine("Skriv brug Evakueringsplan for at læse planen og låse minimappet op.");
    }
  }

  // Returns the words after the command.
  private static string[] GetParameters(string[] input)
  {
    // Reserves space for every word except the first word, which is the command.
    string[] output = new string[input.Length - 1];
    // Copies the remaining words into the parameter array, keeping their original order.
    for (int i = 0; i < output.Length; i++)
    {
      output[i] = input[i + 1];
    }
    return output;
  }
}
