/* Main class for launching the game
 */

class Game
{
  static World world = new World();
  static Context context = new Context(world.GetEntry());

  static void Main(string[] args)
  {
    Console.WriteLine("Du starter din dag på arbejde ved Bland & Håb A/S som nyanset medarbejder, du befinder dig i omklædningsrummmet.");

    context.GetCurrent().Welcome();

    while (context.IsDone() == false)
    {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line == null) continue;

      // parse line
      string[] elements = line.Split(" ");
      string command = elements[0];
      string[] parameters = GetParameters(elements);

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
            return;
          }
          context.Transition(parameters[0]);
          break;
        case "help":
          Console.WriteLine(" - exit  Exit the program");
          Console.WriteLine(" - quit  Exit the program");
          Console.WriteLine(" - bye   Exit the program");
          Console.WriteLine(" - go    Follow an exit");
          Console.WriteLine(" - help  Display a help message");
          break;
        default:
          Console.WriteLine("Dette er ikke en mulig kommando '" + command);
          break;
      }
    }
    Console.WriteLine("Game Over 😥");

    Item pKort = new Item ("1", "Personalekort", "Bruges til at låse bestemte døre op", "Nøglekort", false);
    Item SOP = new Item ("2", "SOP", "Indeholder sikkerhedsprocedurer og låser minimappet op","Dokument", true);
    Item øjenSkyl = new Item ("3", "Øjenskyl", "Bruges i en situation, hvor spilleren har fået kemikalier i øjnene", "Medicin", true);
    Item evak = new Item ("4","Evakueringsplan", "Kan læses for at få information om evakuering", "Dokument", false);
    
  }

  private static string[] GetParameters(string[] input)
  {
    string[] output = new string[input.Length - 1];
    for (int i = 0; i < output.Length; i++)
    {
      output[i] = input[i + 1];
    }
    return output;
  }
}

