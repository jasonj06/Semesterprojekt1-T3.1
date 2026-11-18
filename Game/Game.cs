/* Main class for launching the game
 */

class Game
{
  // Creates the game world, including its rooms and connections.
  static World world = new World();
  // Tracks the current room and whether the game has ended, starting in the entry room.
  static Context context = new Context(world.GetEntry());

  static Inventory inventory = new Inventory();
  
  static void Main(string[] args)
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Typewriter.WriteLine("Velkommen til vores evakuerings spil omkring kemikalie sikkerhed, tryk enter for at forsætte");
    // Show the commands before waiting for Enter.
    ShowCommands();
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

    // Test item
    inventory.AddItem(new Item("0", "Navn", "Beskrivelse", "Type", false));

    Item brandSlukker = new Item("1", "Brandslukker", "Bruges til at slukke mindre brande", "Sikkerhedsudstyr", true);
    
    Item SOP = new Item("2", "SOP", "Indeholder sikkerhedsprocedurer og låser minimappet op i tutorial", "Dokument", true);
    
    Item førstehjælpskasse = new Item("3", "Førstehjælpskasse", "Bruges til at behandle skader og forbrændinger", "Førstehjælp", true);
    
    Item evak = new Item("4", "Evakueringsplan", "Kan læses for at få information om evakuering", "Dokument", false);
    
    Item brandØkse = new Item("5", "Brandøkse", "Bruges til at åbne bestemte blokerede passager", "Værktøj", false);
    //Nye og ændrede items

    // Displays the starting room's welcome message.
    context.ShowCurrentRoom();

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
    // Displays the ending message once the game loop has stopped.
    Typewriter.WriteLine("Game Over 😥");
  }

  // The welcome screen, info and help share this command list.
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

    // Let the player use either "keycard" or the item's name.
    if (string.Equals(itemName, "keycard", StringComparison.OrdinalIgnoreCase))
    {
      itemName = "Personalekort";
    }

    Item? item = inventory.FindItem(itemName);
    if (item == null)
    {
      Typewriter.WriteLine("Du har ikke " + itemName + " i din inventory.");
      return;
    }

    switch (item.GetItemType())
    {
      case "Nøglekort":
        context.GetCurrent().UseKeycard();
        break;
      case "Dokument":
        Typewriter.WriteLine(item.Read());
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

