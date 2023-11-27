public class Inventory
{
    List<Item> items = new();
    int _maxWeight = 50;
    int _weight = 0;
    int i = 0;

    public int Weight
    {
        get
        {
            return _weight;
        }
        private set
        {

        }
    }
    public int MaxWeight
    {
        get
        {
            return _maxWeight;
        }
        private set
        {

        }
    }

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

    // public void DisplayConsumables()
    // {
    //     foreach (Item item in items)
    //     {
    //         if (item is IConsumable)
    //         {


    //             ((IConsumable)item).Consume
    //         }
    //     }
    // }
    public void WriteConsumables()
    {
        i = 0;
        foreach(Item item in items)
        {
            if (item is Potion)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine(item.name);
                i += 2;
            }
        }
    }

    public void AddItem(Item item)
    {
        if (_weight + item.weight > 50)
        {
            Console.WriteLine("Not enough space.");
        }
        else
        {
            items.Add(item);
            _weight += item.weight;
        }
    }
}
