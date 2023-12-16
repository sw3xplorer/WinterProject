using System.ComponentModel;

public class Inventory
{
    List<Item> items = new();
    List<Item> potions = new();
    int _maxWeight = 50;
    int _weight = 0;
    int i = 3;
    int _consumables;
    public int Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            _weight = value;    
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
        if (potions.Count == 0)
        {
            Console.SetCursorPosition(1, i);
            Console.WriteLine("Empty");
        }
        else
        {
            foreach (Item item in potions)
            {
                if (item is Potion || item is LargePotion)
                {
                    Console.SetCursorPosition(1, i);
                    Console.WriteLine($"{item.Name} - Sell: {item.SellPrice}");
                    i += 2;
                }
            }
        }
    }

    public void WriteInventory()
    {
        i = 3;
        if (items.Count == 0)
        {
            Console.SetCursorPosition(1, i);
            Console.WriteLine("Empty");
        }
        else
        {
            foreach(Item item in Inv)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine($"{item.Name} - Sell: {item.SellPrice}");
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
        else if (item is Potion)
        {
            potions.Add(item);
            _weight += item.weight;
        }
        else
        {
            items.Add(item);
            _weight += item.weight;
        }
    }
}
