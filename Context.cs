/* Context class to hold all context relevant to a session.
 */
 
class Context {
  Room current;
  bool done = false;

  public Context (Room node) {
    current = node;
  }
  
  public Room GetCurrent() {
    return current;
  }
  
  public void Transition (string destination) {
    Room? next = current.FollowEdge(destination);
    if (next == null) {
      Console.WriteLine("Du kan ikke gå til " + destination + " herfra.");
      return;
    }
    // The player must unlock the destination before entering it.
    if (next.IsLocked) {
      Console.WriteLine("Døren er låst. Hvis du har et nøglekort, kan du skrive brug keycard.");
      return;
    }
    current.Goodbye();
    current = next;
    current.Welcome();
}


  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

