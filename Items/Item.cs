// Represents an item that can be found in a room or carried by the player.
public class Item
{
    private string id;          // The item's identifier.
    private string name;        // The item's name.
    private string description; // Text describing the item.
    private string type;        // The item's category, such as an access card.
    private bool consumable;    // True if the item should be used up after use.

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
