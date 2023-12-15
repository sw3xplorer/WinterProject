public class Inventory
{
    List<Item> items = new();
    List<Item> potions = new();
    int _maxWeight = 50;
    int _weight = 0;
    int i = 3;
    int _consumables;
    public List<Item> Potions
    {
        get
        {
            return potions;
        }
        private set
        {

        }
    }

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
        i = 3;
        foreach (Item item in potions)
        {
            if (item is Potion || item is LargePotion)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine(item.Name);
                i += 2;
            }
        }
    }


    public void WriteInventory()
    {
        i = 3;
        foreach(Item item in Inv)
        {
            Console.SetCursorPosition(1, i);
            Console.WriteLine(item.Name);
            i += 2;
        }
        foreach(Item potion in Potions)
        {
            Console.SetCursorPosition(1, i);
            Console.WriteLine(potion.Name);
            i += 2;
        }

    }

    public void AddItem(Item item)
    {
        if (_weight + item.weight > 50)
        {
            Console.WriteLine("Not enough space.");
        }
        else if (item is Potion || item is LargePotion)
        {
            potions.Add(item);
        }
        else
        {
            items.Add(item);
            _weight += item.weight;
        }
    }
}
