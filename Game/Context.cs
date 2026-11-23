/* Context class to hold all context relevant to a session.
 */
 
class Context {
  Room current;
  bool done = false;
  public bool IsExitUnblocked = false;
  public bool IsCanteenFireOut = false;
  private readonly Minimap minimap = new Minimap();
  public TurnTimer Timer { get; } = new TurnTimer();

  public Context (Room node) {
    current = node;
  }
  
  public Room GetCurrent() {
    return current;
  }

  public void ShowCurrentRoom() {
    Console.WriteLine("Tur: " + Timer.CurrentTurn);
    var (textWidth, mapEndRow) = minimap.Show(current);
    current.Welcome(textWidth);

    // Keep the command prompt below the map.
    if (textWidth > 0 && Console.CursorTop < mapEndRow) {
      Console.SetCursorPosition(0, mapEndRow);
    }
  }
  
  public void Transition (string destination) {
    Room? next = current.FollowEdge(destination);
    if (next == null) {
      Typewriter.WriteLine("Du kan ikke gå til " + destination + " herfra.");
      return;
    }
    // The player must unlock the destination before entering it.
    if (next.IsLocked) {
      Typewriter.WriteLine("Døren er låst. Hvis du har et nøglekort, kan du skrive brug keycard.");
      return;
    }
    
    if(destination.ToLower() == "exit" && !IsExitUnblocked)
    {
        Typewriter.WriteLine("Døren er blokeret! Du skal bruge en brandøkse for komme igennem.");
        return;
    }

    if(destination.ToLower() == "kantine" && !IsCanteenFireOut)
    {
        Typewriter.WriteLine("Der er brand i kantinen! Du skal bruge en brandslukker for komme igennem.");
        return;
    }
    
    current.Goodbye();
    current = next;
    if (!Console.IsOutputRedirected) {
      Console.Clear();
    }

    // Only a successful move advances the timer.
    Timer.Advance();
    if (done) {
      return;
    }

    ShowCurrentRoom();
    if (current.GetName() == "Samlingspunkt") {
      Quiz.StartQuiz();
    }
  }


  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

