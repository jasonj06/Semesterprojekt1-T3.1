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
  public string MapLabel { get; }
  public int MapColumn { get; }
  public int MapRow { get; }

  public Room(string name, string mapLabel, int mapColumn, int mapRow, string entryMessage) : base(name)
  {
    MapLabel = mapLabel;
    MapColumn = mapColumn;
    MapRow = mapRow;
    this.entryMessage = entryMessage;
  }

  public bool HasExitTo(Room room)
  {
    return edges.ContainsValue(room);
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
      Typewriter.WriteLine("Du finder ingen genstande i rummet.");
      return;
    }

    Typewriter.WriteLine("Du fandt følgende genstande:");
    foreach (Item item in items)
    {
      Console.WriteLine(" - " + item.GetName() + " (tag " + item.GetName() + ")");
    }
  }

  public void TakeItem(string itemName, Inventory inventory)
  {
    if (!searched)
    {
      Typewriter.WriteLine("Skriv søg for at lede efter genstande i rummet først.");
      return;
    }

    Item? item = roomItems.FindItem(itemName);
    if (item == null)
    {
      Typewriter.WriteLine("Der er ingen genstand med navnet " + itemName + " i rummet.");
      return;
    }

    // Move the item from the room to the player's inventory.
    inventory.AddItem(item);
    roomItems.RemoveItem(item);
    Typewriter.WriteLine("Du tog " + item.GetName() + ".");
  }

  public void UseKeycard()
  {
    // Look for a locked room the player can reach from here.
    foreach (Room destination in edges.Values)
    {
      if (destination.IsLocked)
      {
        destination.IsLocked = false;
        Typewriter.WriteLine("Du låste døren til " + destination.GetName() + " op med dit nøglekort.");
        return;
      }
    }

    Typewriter.WriteLine("Der er ingen låste døre, hvor du kan bruge nøglekortet her.");
  }

  public void Welcome(int textWidth)
  {
    Typewriter.WriteLine("Du er nu i " + name);
    WriteEntryMessage(textWidth);
    Console.WriteLine("Du kan gå til:");
    foreach (KeyValuePair<string, Node> exit in edges)
    {
      string direction = exit.Key switch
      {
        "north" => "nord",
        "south" => "syd",
        "west" => "vest",
        "east" => "øst",
        _ => exit.Key
      };
      Console.WriteLine(" - " + exit.Value.GetName() + " (" + direction + ")");
    }
  }

  private void WriteEntryMessage(int width)
  {
    if (width == 0)
    {
      Typewriter.WriteLine(entryMessage);
      return;
    }

    foreach (string paragraph in entryMessage.ReplaceLineEndings("\n").Split('\n'))
    {
      string line = paragraph;
      while (line.Length > width)
      {
        int end = line.LastIndexOf(' ', width);
        if (end <= 0)
        {
          end = width;
        }
        Typewriter.WriteLine(line[..end]);
        line = line[end..].TrimStart();
      }
      Typewriter.WriteLine(line);
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
