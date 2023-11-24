public class Inventory
{
    List<Item> items = new();
    int maxWeight = 50;
    int weight = 0;

    public List<Item> Inv
    {
        get
        {
            return items;
        }
        private set
        {

        }
    }

    public void DisplayConsumables()
    {
        foreach (Item item in items)
        {
            if (item is IConsumable)
            {


                ((IConsumable)item).Consume
            }
        }
    }

    public void AddItem(Item item)
    {
        if (weight + item.weight > 50)
        {
            Console.WriteLine("Not enough space");
        }
        else
        {
            items.Add(item);
        }
    }
}
