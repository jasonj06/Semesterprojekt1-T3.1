class Minimap
{
  private const int Radius = 2;
  private const int TileWidth = 6;
  private const int MapWidth = (2 * Radius + 1) * (TileWidth + 1) - 1;
  private readonly Dictionary<(int, int), Room> visited = new Dictionary<(int, int), Room>();

  public (int TextWidth, int EndRow) Show(Room current)
  {
    visited[(current.MapColumn, current.MapRow)] = current;
    List<string> lines = DrawRooms(current);

    if (!Console.IsOutputRedirected)
    {
      int left = Console.WindowWidth - MapWidth - 1;
      int top = Console.CursorTop;
      int endRow = top + lines.Count;
      if (left >= 44 && endRow < Console.BufferHeight)
      {
        for (int i = 0; i < lines.Count; i++)
        {
          Console.SetCursorPosition(left, top + i);
          Console.Write(lines[i]);
        }
        Console.SetCursorPosition(0, top);
        return (left - 4, endRow);
      }
    }

    // On a narrow screen, give the map its own lines.
    foreach (string line in lines)
    {
      Console.WriteLine(line);
    }
    return (0, 0);
  }

  private List<string> DrawRooms(Room current)
  {
    List<string> lines = new List<string>();
    int lastRow = current.MapRow + Radius;
    int lastColumn = current.MapColumn + Radius;

    for (int row = current.MapRow - Radius; row <= lastRow; row++)
    {
      string rooms = "";
      string doors = "";
      for (int column = current.MapColumn - Radius; column <= lastColumn; column++)
      {
        visited.TryGetValue((column, row), out Room? room);
        if (room == null)
        {
          rooms += new string(' ', TileWidth);
        }
        else
        {
          // Leave two spaces for the pin in each room.
          string marker = room == current ? "📍" : "  ";
          rooms += "[" + room.MapLabel + marker + "]";
        }

        // Only connect rooms that have been visited and share an exit.
        rooms += column < lastColumn && HasDoor(room, column + 1, row) ? "-" : " ";
        doors += HasDoor(room, column, row + 1) ? "  |    " : new string(' ', TileWidth + 1);
      }

      lines.Add(rooms.TrimEnd());
      if (row < lastRow)
      {
        lines.Add(doors.TrimEnd());
      }
    }
    

    while (lines[0].Length == 0)
    {
      lines.RemoveAt(0);
    }
    while (lines[lines.Count - 1].Length == 0)
    {
      lines.RemoveAt(lines.Count - 1);
    }
    lines.Insert(0, "Minimap");
    return lines;
  }

  private bool HasDoor(Room? room, int column, int row)
  {
    return room != null &&
           visited.TryGetValue((column, row), out Room? neighbor) &&
           (room.HasExitTo(neighbor) || neighbor.HasExitTo(room));
  }
}
