/* Node class for modeling graphs
 */

class Node {
  protected string name;
  protected Dictionary<string, Node> edges = new Dictionary<string, Node>(StringComparer.OrdinalIgnoreCase);
  
  public Node (string name) {
    this.name = name;
  }
  
  public String GetName () {
    return name;
  }
  
  public void AddEdge (string name, Node node) {
    edges.Add(name, node);
  }
  
  public virtual Node? FollowEdge (string destination) {
    // Try the direction shortcut first, then look for a room by name.
    if (edges.TryGetValue(destination, out Node? next)) {
      return next;
    }

    foreach (Node node in edges.Values) {
      if (string.Equals(node.GetName(), destination, StringComparison.OrdinalIgnoreCase)) {
        return node;
      }
    }

    return null;
  }
}

