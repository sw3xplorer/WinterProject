public class Player : Character
{
    List<string> locations = new() { "Shop", "Wilderness", "Howling Grotto" };
    // Potion potion = new();
    // LargePotion largePotion = new();
    public Inventory inventory = new();
    int coins = 0;
    int _choice = 0;
    string _location = "Shop";
    bool _confirmAction = false;
    bool _confirmItem = false;
    public Player()
    {
        _maxHp = 200;
        // _hp = _maxHp;
        _hp = 100;
        // inventory.AddItem(potion);
        // inventory.AddItem(potion);
        // inventory.AddItem(largePotion);
        // inventory.AddItem(largePotion);
        weapon = new IronSword();
    }

    public string Location
    {
        get
        {
            return _location;
        }

        set
        {
            _location = value;
        }
    }

    public void WriteLocations()
    {
        int i = 3;
        foreach (string location in locations)
        {
            Console.SetCursorPosition(1, i);
            Console.WriteLine(location);
            i += 2;
        }
    }


    // Player can move to a new location.

    public void Move()
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("Move?");
        if(Select(1, 5, 2, "Yes", "No") && _choice == 0)
        {
            Text.ClearArea(0, 3, 10, 10);
            _confirmAction = false;
            WriteLocations();
            while(!_confirmAction)
            {
                if(Select(locations.Count() - 1, 3, 2, "", ""))
                {
                    (Location, _confirmAction) = SetLocation();
                }
            }
            Console.Clear();
        }
    }

    // Player can either attack or use item.
    public void Control(Character target)
    {

        if(Select(1, 3, 2, "Attack", "Item") && _choice == 0)
        {
            Attack(target);
        }
        else
        {
            _confirmAction = false;
            Text.ClearArea(0, 3, 10, 8);
            inventory.WriteConsumables();
            if(Select(inventory.Potions.Count() - 1, 3, 2, "", ""))
            {
                Text.ClearArea(0, 3, 80, Console.LargestWindowHeight - 1);
                if (inventory.Potions[_choice] is Potion) // Check if the item IS a potion
                {
                    Potion p = (Potion)inventory.Potions[_choice]; //Cast that item to a potion to not crash the code
                    p.Consume(this);
                }
            }
        }



       
    }

    public void Shop()
    {
        if(Select(1, 3, 2, "Buy", "Sell") && _choice == 0)
        {
            Game.WriteItems();
        }
    }

    public (string, bool) SetLocation() // Returns two values.
    {
        _confirmAction = false;
        string location = "";
        if(_location == locations[_choice])
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("You are already here.");
            location = locations[_choice];
            return(location, false);
        }
        else
        {
            Text.ClearArea(0, 3, 20, 12);
            location = locations[_choice];
            return(location, true);
        }
    }

    public bool Select(int maxChoice, int startPos, int interval, string text1, string text2)
    {
        _confirmAction = false;
        Console.SetCursorPosition(1, startPos);
        Console.WriteLine(text1);
        Console.SetCursorPosition(1, startPos + interval);
        Console.WriteLine(text2);
        while (!_confirmAction)
        {
            if (_choice >= 0 && _choice <= maxChoice)
            {
                Console.SetCursorPosition(0, startPos + _choice * interval);
                Console.WriteLine(">");
            }

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow && _choice < maxChoice)
            {
                _choice++;
                Console.SetCursorPosition(0, startPos + ((_choice - 1) * interval));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.UpArrow && _choice > 0)
            {
                _choice--;
                Console.SetCursorPosition(0, startPos + ((_choice + 1) * interval));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                _confirmAction = true;
            }
        }
        return true;
    }
}


