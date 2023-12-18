public class Player : Character
{
    // VARIABLES
    List<string> locations = new() { "Shop", "Wilderness", "Howling Grotto" };
    public Inventory inventory = new();
    int _choice = 0;

    // Choice variable used as an index to define what item is bought, sold, used, etc.
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
    // Variables for location and confirming actions.
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

    // Able to read the player's armor, weapon and location.
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
        // Reset exitshop, in case player now moved to the shop so they don't instantly get kicked out.
        exitShop = false;

        // Place cursors on the right place to write where I want.
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("Move?");

        // Ask the player if they wish to move. And if it returns true and index was 0:
        if (Select(1, 5, 2, "Yes", "No", false) && Choice == 0)
        {
            // Clear the text, then write the locations. Reset confirm.
            Text.ClearArea(0, 3, 10, 10);
            _confirmAction = false;
            WriteLocations();
            while (!_confirmAction)
            {
                if (Select(locations.Count() - 1, 3, 2, "", "", false))
                {
                    // If returns true and you are in the shop, makes you able to leave the shop.
                    if (Location == "Shop")
                    {
                        exitShop = true;
                    }
                    // Then set the location to the desired one.
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
            // If you wish to use item, clear screen and write consumables.
            _confirmAction = false;
            Text.ClearArea(0, 3, 10, 8);
            inventory.WriteConsumables();
            if (Select(inventory.Potions.Count() - 1, 3, 2, "", "", false))
            {
                // Try to use a potion. Since the inventory might be empty, trying to use a potion then would crash the program.
                // If you then press enter, it will run the catch code.
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

    // This could be moved to its own class instead...
    public void Shop()
    {
        // Update the UI.
        Text.PlayerInfo(this, inventory);
        Console.SetCursorPosition(0, Console.LargestWindowHeight - 2);
        Console.WriteLine("Press ESC to go back.");
        // New instance of shop to prevent RNG manipulation. Refreshes when entering shop once again.
        Shop shop = new();

        while (!exitShop)
        {
            while (true)
            {
                _escKeyPressed = false;
                if (Select(1, 3, 2, "Buy", "Sell", true) && Choice == 0 && _escKeyPressed == false)
                {
                    // If you want to buy, display current stock.
                    shop.WriteItems();
                    if (Select(2, 3, 7, "", "", true) && _escKeyPressed == false)
                    {
                        // Add item to the inventory.
                        shop.Purchase(inventory, this);
                        Text.ClearArea(0, 2, 40, 40);
                    }
                    else if (_escKeyPressed)
                    {
                        // Go back to the Buy/Sell menu.
                        Text.ClearArea(0, 2, 40, 40);
                    }
                }
                else if (Choice == 1 && _escKeyPressed == false)
                {
                    if (Select(1, 3, 2, "Equipment", "Potions", false) && Choice == 0)
                    {
                        // Write the items in the inventory (NOT POTIONS).
                        Text.ClearArea(0, 2, 40, 40);
                        inventory.WriteInventory();
                        if (Select(inventory.Inv.Count() - 1, 3, 2, "", "", true) && _escKeyPressed == false)
                        {
                            // Sells the item.
                            shop.Sell(this, inventory);
                            Text.ClearArea(0, 2, 40, 40);
                        }
                    }

                    else if (Choice == 1)
                    {
                        // Same thing but for the potions. 
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
                // Else break the loop.
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

    public (string, bool) SetLocation() // Returns two values. String for location name, bool for confirming action.
    {
        _confirmAction = false;
        string location = "";
        if (_location == locations[Choice]) // If player location is the same as the one they are selecting:
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

    // Select function. Works based on the given data. Made to save having a separate choice funtion for different actions.
    // maxChoice = How many options the player can choose between. (Works as index)
    // startPos = Where the text starts writing.
    // interval = The gap between the text representing the choices. 
    // text1 = First text.
    // text2 = Second text.
    // (Used for yes/no prompts)
    // escKey = Determines if ESC key can be used in that function call.
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