/* Room class for modeling spaces (rooms, caves, ...)
 */

class Room : Node
{
  private readonly string entryMessage;
  private Inventory roomItems = new Inventory();
  // Each room remembers if the player has searched it.
  private bool searched = false;

 //bool to make a room lockable
  public bool IsLocked { get; set; } = false;

  public Room(string name, string entryMessage) : base(name)
  {
    this.entryMessage = entryMessage;
  }

  public void AddItem(Item item)
  {
    roomItems.AddItem(item);
  }

  public void Search()
  {
    searched = true;
    List<Item> items = roomItems.GetItems();
    if (items.Count == 0)
    {
      Console.WriteLine("Du finder ingen genstande i rummet.");
      return;
    }

    Console.WriteLine("Du fandt følgende genstande:");
    foreach (Item item in items)
    {
      Console.WriteLine(" - " + item.GetName() + " (tag " + item.GetName() + ")");
    }
  }

  public void TakeItem(string itemName, Inventory inventory)
  {
    if (!searched)
    {
      Console.WriteLine("Skriv søg for at lede efter genstande i rummet først.");
      return;
    }

    Item? item = roomItems.FindItem(itemName);
    if (item == null)
    {
      Console.WriteLine("Der er ingen genstand med navnet " + itemName + " i rummet.");
      return;
    }

    // Move the item from the room to the player's inventory.
    inventory.AddItem(item);
    roomItems.RemoveItem(item);
    Console.WriteLine("Du tog " + item.GetName() + ".");
  }

  public void UseKeycard()
  {
    // Look for a locked room the player can reach from here.
    foreach (Room destination in edges.Values)
    {
      if (destination.IsLocked)
      {
        destination.IsLocked = false;
        Console.WriteLine("Du låste døren til " + destination.GetName() + " op med dit nøglekort.");
        return;
      }
    }

    Console.WriteLine("Der er ingen låste døre, hvor du kan bruge nøglekortet her.");
  }

  public void Welcome()
  {
    Console.WriteLine("Du er nu i " + name);
    Console.WriteLine(entryMessage);
    Console.WriteLine("Du kan gå til:");
    foreach (Node destination in edges.Values)
    {
      Console.WriteLine(" - " + destination.GetName());
    }
  }

  public void Goodbye()
  {
  }

  public override Room? FollowEdge(string destination)
  {
    return (Room?)base.FollowEdge(destination);
  }
}
