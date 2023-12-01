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
        _hp = _maxHp;
        // inventory.AddItem(potion);
        // inventory.AddItem(potion);
        // inventory.AddItem(largePotion);
        // inventory.AddItem(largePotion);
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
            if (_location != location)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine(location);
                i += 2;
            }
        }
    }


    // Player can move to a new location.

    public void Move()
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("Move?");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine("Yes");
        Console.SetCursorPosition(1, 7);
        Console.WriteLine("No");
        while (!_confirmAction)
        {
            if (_choice >= 0 && _choice <= 1)
            {
                Console.SetCursorPosition(0, 5 + _choice * 2);
                Console.WriteLine(">");
            }

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow && _choice < 1)
            {
                _choice++;
                Console.SetCursorPosition(0, 5 + ((_choice - 1) * 2));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.UpArrow && _choice > 0)
            {
                _choice--;
                Console.SetCursorPosition(0, 5 + ((_choice + 1) * 2));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                _confirmAction = true;
                Text.ClearArea(0, 3, 10, 10);
            }

            // CHOOSE LOCATION

            if (_confirmAction && _choice == 0)
            {
                _confirmAction = false;
                WriteLocations();
                while (!_confirmAction)
                {
                    if (_choice >= 0 && _choice <= 1)
                    {
                        Console.SetCursorPosition(0, 3 + _choice * 2);
                        Console.WriteLine(">");
                    }

                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.DownArrow && _choice < 1)
                    {
                        _choice++;
                        Console.SetCursorPosition(0, 3 + ((_choice - 1) * 2));
                        Console.WriteLine(" ");
                    }
                    else if (key.Key == ConsoleKey.UpArrow && _choice > 0)
                    {
                        _choice--;
                        Console.SetCursorPosition(0, 3 + ((_choice + 1) * 2));
                        Console.WriteLine(" ");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        _confirmAction = true;
                        Text.ClearArea(0, 3, 20, 10);
                    }
                }
            }
        }
    }

    // Player can either attack or use item.
    public void Control()
    {
        _confirmAction = false;
        Console.SetCursorPosition(1, 3);
        Console.WriteLine("Attack");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine("Item");
        while (!_confirmAction)
        {
            _confirmItem = false;
            if (_choice >= 0 && _choice <= 1)
            {
                Console.SetCursorPosition(0, 3 + _choice * 2);
                Console.WriteLine(">");
            }

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow && _choice < 1)
            {
                _choice++;
                Console.SetCursorPosition(0, 3 + ((_choice - 1) * 2));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.UpArrow && _choice > 0)
            {
                _choice--;
                Console.SetCursorPosition(0, 3 + ((_choice + 1) * 2));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                _confirmAction = true;
                Attack();
            }

            // ITEM CHOICE

            if (_choice == 1 && _confirmAction)
            {
                Text.ClearArea(0, 3, 10, 8);
                inventory.WriteConsumables();
                while (!_confirmItem)
                {
                    if (_choice >= 0 && _choice <= inventory.Inv.Count() - 1)
                    {
                        Console.SetCursorPosition(0, 3 + _choice * 2);
                        Console.WriteLine(">");
                    }

                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.DownArrow && _choice < inventory.Inv.Count() - 1)
                    {
                        _choice++;
                        Console.SetCursorPosition(0, 3 + ((_choice - 1) * 2));
                        Console.WriteLine(" ");
                    }
                    else if (key.Key == ConsoleKey.UpArrow && _choice > 0)
                    {
                        _choice--;
                        Console.SetCursorPosition(0, 3 + ((_choice + 1) * 2));
                        Console.WriteLine(" ");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        _confirmItem = true;
                        Text.ClearArea(0, 3, 80, Console.LargestWindowHeight - 1);
                    }

                    // if(_confirmItem && _choice == inventory.Inv.Count()-1)
                    // {
                    //     Text.ClearArea(0, 1, 30, 60);
                    //     Console.SetCursorPosition(1, 3);
                    //     Console.WriteLine("Attack");
                    //     Console.SetCursorPosition(1, 5);
                    //     Console.WriteLine("Item");
                    //     _confirmAction = false;
                    // }
                }
            }
        }
    }
}
