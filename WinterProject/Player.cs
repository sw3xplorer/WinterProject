public class Player : Character
{
    // Potion potion = new();
    // LargePotion largePotion = new();
    public Inventory inventory = new();
    int coins = 0;
    int _choice = 0;
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

    // Player can either attack or use item.
    public void Control()
    {
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
            }

            // ITEM CHOICE

            if (_choice == 1 && _confirmAction)
            {
                Text.ClearArea(0, 3, 10, 8);
                inventory.WriteConsumables();
                while (!_confirmItem)
                {
                    if (_choice >= 0 && _choice <= inventory.Inv.Count()-1)
                    {
                        Console.SetCursorPosition(0, 3 + _choice * 2);
                        Console.WriteLine(">");
                    }

                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.DownArrow && _choice < inventory.Inv.Count()-1)
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
