using System.ComponentModel;

public class Inventory
{
    // Split potions and non potions into two lists due to complexity when player wanted to use potions.
    // The index from the choice would be used in the inventory, which meant that it would try to use
    // weapons and armor as potions which would just make THAT certain potion useless.
    List<Item> items = new();
    List<Item> potions = new();
    int _maxWeight = 50;
    int _weight = 0;
    int i = 3;
    // int _consumables;
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

// Micke's solution. Avoided since it would not be graded, since it's not my code.
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
                    Console.WriteLine($"{item.Name} - Sell: {item.SellPrice}"); //Write potion name and sell price.
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

    // Adds item to inventory.
    public void AddItem(Item item)
    {
        if (_weight + item.weight > 50)
        {
            Console.SetCursorPosition(0, 36);
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
