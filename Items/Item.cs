// Represents an item that can be found in a room or carried by the player.
public class Item
{
    private string id;
    private string name;
    private string description;
    private string type;
    private bool consumable;

    // Creates an item and stores the values passed to the constructor.
    public Item(string id, string name, string description,
                string type, bool consumable)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.consumable = consumable;
    }

    // Returns the item's identifier.
    public string GetId()
    {
        return id;
    }

    // Returns the item's name.
    public string GetName()
    {
        return name;
    }

    // Returns the text describing the item.
    public string GetDescription()
    {
        return description;
    }

    // Returns the item's category.
    public string GetItemType()
    {
        return type;
    }

    // Reports whether the item should be used up after use.
    public bool IsConsumable()
    {
        return consumable;
    }

    // Returns the description as the item's readable text.
    public string Read()
    {
        return description;
    }
}
