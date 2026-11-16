/* Context class to hold all context relevant to a session.
 */
 
class Context {
  Room current;
  bool done = false;
  private readonly Minimap minimap = new Minimap();

  public Context (Room node) {
    current = node;
  }
  
  public Room GetCurrent() {
    return current;
  }

  public void ShowCurrentRoom() {
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
    current.Goodbye();
    current = next;
    if (!Console.IsOutputRedirected) {
      Console.Clear();
    }
    ShowCurrentRoom();
  }


  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

