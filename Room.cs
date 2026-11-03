/* Room class for modeling spaces (rooms, caves, ...)
 */

class Room : Node
{
  public Room(String name) : base(name)
  {
  }

  public void Welcome()
  {
    Console.WriteLine("Du er nu i " + name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Du ser disse nogle døre som fører til:");
    foreach (String exit in exits)
    {
      Console.WriteLine(" - " + exit);
    }
  }

  public void Goodbye()
  {
  }

  public override Room FollowEdge(string direction)
  {
    return (Room)(base.FollowEdge(direction));
  }
}
