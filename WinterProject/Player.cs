public class Player : Character
{
    // VARIABLES
    List<string> locations = new() { "Shop", "Wilderness", "Howling Grotto" };
    public Inventory inventory = new();
    int coins = 0;
    int _choice = 0;

    public int Choice
    {
        get
        {
            return _choice;
        }
        set
        {
            _choice = value;
        }
    }
    string _location = "Shop";
    bool _confirmAction = false;
    bool _escKeyPressed = false;
    bool exitShop = false;

    // CONSTRUCTOR

    public Player()
    {
        _maxHp = 200;
        _hp = _maxHp;
        weapon = new IronSword();
        inventory.AddItem(new IronSword());
        inventory.AddItem(new Potion());
        inventory.AddItem(new Potion());
        inventory.AddItem(new Potion());
    }

    // PROPERTIES

    public Armor Armor
    {
        get
        {
            return armor;
        }
        private set
        {

        }
    }

    public Weapon Weapon
    {
        get
        {
            return weapon;
        }
        private set
        {

        }
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

    // METHODS

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
        exitShop = false;
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("Move?");
        if (Select(1, 5, 2, "Yes", "No", false) && Choice == 0)
        {
            Text.ClearArea(0, 3, 10, 10);
            _confirmAction = false;
            WriteLocations();
            while (!_confirmAction)
            {
                if (Select(locations.Count() - 1, 3, 2, "", "", false))
                {
                    if (Location == "Shop")
                    {
                        exitShop = true;
                    }
                    (Location, _confirmAction) = SetLocation();
                }
            }
        }
        Console.Clear();
    }

    // Player can either attack or use item.
    public void Control(Character target)
    {
        if (Select(1, 3, 2, "Attack", "Item", false) && Choice == 0)
        {
            Attack(target);
        }
        else
        {
            _confirmAction = false;
            Text.ClearArea(0, 3, 10, 8);
            inventory.WriteConsumables();
            if (Select(inventory.Potions.Count() - 1, 3, 2, "", "", false))
            {
                try
                {
                    if (inventory.Potions[Choice] is Potion) // Check if the item IS a potion
                    {
                        Potion p = (Potion)inventory.Potions[Choice]; //Cast that item to a potion to not crash the code
                        p.Consume(this);
                        inventory.Potions.RemoveAt(Choice);
                    }
                }
                catch
                {
                    Console.WriteLine("Nothing to use.");
                    Task.Delay(1500).Wait();
                }
                Text.ClearArea(0, 3, 80, Console.LargestWindowHeight - 1);
            }
        }
    }

    public void Shop()
    {
        Text.PlayerInfo(this, inventory);
        Console.SetCursorPosition(0, Console.LargestWindowHeight - 2);
        Console.WriteLine("Press ESC to go back.");
        Shop shop = new();

        while (!exitShop)
        {
            while (true)
            {
                _escKeyPressed = false;
                if (Select(1, 3, 2, "Buy", "Sell", true) && Choice == 0 && _escKeyPressed == false)
                {
                    shop.WriteItems();
                    if (Select(2, 3, 7, "", "", true) && _escKeyPressed == false)
                    {
                        shop.Purchase(inventory, this);
                        Text.ClearArea(0, 2, 40, 40);
                    }
                    else if (_escKeyPressed)
                    {
                        Text.ClearArea(0, 2, 40, 40);
                    }
                }
                else if (Choice == 1 && _escKeyPressed == false)
                {
                    if (Select(1, 3, 2, "Equipment", "Potions", false) && Choice == 0)
                    {
                        Text.ClearArea(0, 2, 40, 40);
                        inventory.WriteInventory();
                        if (Select(inventory.Inv.Count() - 1, 3, 2, "", "", true) && _escKeyPressed == false)
                        {
                            shop.Sell(this, inventory);
                            Text.ClearArea(0, 2, 40, 40);
                        }
                    }

                    else if (Choice == 1)
                    {
                        Text.ClearArea(0, 2, 40, 40);
                        inventory.WriteConsumables();
                        if (Select(inventory.Potions.Count() - 1, 3, 2, "", "", true) && _escKeyPressed == false)
                        {
                            shop.SellPotion(this, inventory);
                            Text.ClearArea(0, 2, 40, 40);
                        }
                    }

                    if (_escKeyPressed)
                    {
                        Text.ClearArea(0, 2, 40, 40);
                    }
                }
                else
                {
                    break;
                }
            }
            Text.ClearArea(0, 1, 20, 30);
            Move();
            Console.Clear();
        }
    }

    public (string, bool) SetLocation() // Returns two values.
    {
        _confirmAction = false;
        string location = "";
        if (_location == locations[Choice])
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("You are already here.");
            location = locations[Choice];
            return (location, false);
        }
        else
        {
            Text.ClearArea(0, 3, 20, 12);
            location = locations[Choice];
            return (location, true);
        }
    }

    public bool Select(int maxChoice, int startPos, int interval, string text1, string text2, bool escKey)
    {
        Choice = 0;
        _confirmAction = false;
        Console.SetCursorPosition(1, startPos);
        Console.WriteLine(text1);
        Console.SetCursorPosition(1, startPos + interval);
        Console.WriteLine(text2);
        while (!_confirmAction)
        {
            if (Choice >= 0 && Choice <= maxChoice)
            {
                Console.SetCursorPosition(0, startPos + Choice * interval);
                Console.WriteLine(">");
            }

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow && Choice < maxChoice)
            {
                Choice++;
                Console.SetCursorPosition(0, startPos + ((Choice - 1) * interval));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.UpArrow && Choice > 0)
            {
                Choice--;
                Console.SetCursorPosition(0, startPos + ((Choice + 1) * interval));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                _confirmAction = true;
            }
            else if (escKey && key.Key == ConsoleKey.Escape)
            {
                _escKeyPressed = true;
                _confirmAction = true;
            }
        }
        return true;
    }
}


