/* Context class to hold all context relevant to a session.
 */
 
class Context {
  Room current;
  bool done = false;

//placeholder indtil vi får keycard i inventory
public bool keycard = false;
  
  public Context (Room node) {
    current = node;
  }
  
  public Room GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    Room next = current.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
      return;
    }
    if (next.IsLocked){
        if(keycard == true){  
        Console.WriteLine("Du bipper dit nøglekort");
        next.IsLocked = false;
    } else {
        Console.WriteLine("Døren er låst");
        return;
    }
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

