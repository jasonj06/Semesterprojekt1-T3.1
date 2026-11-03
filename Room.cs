/* Room class for modeling spaces (rooms, caves, ...)
 */

class Room : Node {
    public Room (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.WriteLine("You are now at "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Room FollowEdge (string direction) {
    return (Room) (base.FollowEdge(direction));
  }
}
