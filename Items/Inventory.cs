public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    // Return the matching item, or null if the list does not contain it.
    public Item? FindItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (string.Equals(item.GetName(), itemName, StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }
        return null;
    }

    public List<Item> GetItems()
    {
        return items;
    }
}
