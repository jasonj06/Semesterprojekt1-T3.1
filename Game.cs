/* Main class for launching the game
 */

class Game
{
  // Creates the game world, including its rooms and connections.
  static World world = new World();
  // Tracks the current room and whether the game has ended, starting in the entry room.
  static Context context = new Context(world.GetEntry());

  static void Main(string[] args)
  {
    Console.WriteLine("Du starter din dag på arbejde ved Bland & Håb A/S som nyanset medarbejder, du befinder dig i omklædningsrummmet.");

    // Displays the starting room's welcome message.
    context.GetCurrent().Welcome();

    // Keeps asking for commands until the context marks the game as finished.
    while (context.IsDone() == false)
    {
      // Shows a prompt and reads a line typed by the player.
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line == null) continue;

      string[] elements = line.Split(" ");
      string command = elements[0];
      string[] parameters = GetParameters(elements);

      // Runs the code matching the player's command.
      switch (command)
      {
        case "exit":
        case "quit":
        case "bye":
          context.MakeDone();
          break;
        case "go":
          if (parameters.Length != 1)
          {
            Console.WriteLine("I don't seem to know where that is 🤔");
            // Leaves Main and ends the program when the parameter count is incorrect.
            return;
          }
          // Asks the context to move through the exit named by the parameter.
          context.Transition(parameters[0]);
          break;
        case "help":
          // Lists the available commands and what they do.
          Console.WriteLine(" - exit  Exit the program");
          Console.WriteLine(" - quit  Exit the program");
          Console.WriteLine(" - bye   Exit the program");
          Console.WriteLine(" - go    Follow an exit");
          Console.WriteLine(" - help  Display a help message");
          break;
        default:
          // Handles input that does not match any of the commands above.
          Console.WriteLine("Dette er ikke en mulig kommando '" + command);
          break;
      }
    }
    // Displays the ending message once the game loop has stopped.
    Console.WriteLine("Game Over 😥");

    // Creates the four items. These statements currently run after the game loop finishes.
    Item pKort = new Item ("1", "Personalekort", "Bruges til at låse bestemte døre op", "Nøglekort", false);
    Item SOP = new Item ("2", "SOP", "Indeholder sikkerhedsprocedurer og låser minimappet op","Dokument", true);
    Item øjenSkyl = new Item ("3", "Øjenskyl", "Bruges i en situation, hvor spilleren har fået kemikalier i øjnene", "Medicin", true);
    Item evak = new Item ("4","Evakueringsplan", "Kan læses for at få information om evakuering", "Dokument", false);
    
  }

  // Returns all words after the command. For example, "go north" gives the parameter "north".
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

