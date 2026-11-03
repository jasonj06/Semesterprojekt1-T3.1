public class Item
{
    private string id;
    private string name;
    private string description;
    private string type;
    private bool consumable;

    public Item(string id, string name, string description,
                string type, bool consumable)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.consumable = consumable;
    }

    public string GetId()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetItemType()
    {
        return type;
    }

    public bool IsConsumable()
    {
        return consumable;
    }

    public string Read()
    {
        return description;
    }
}
