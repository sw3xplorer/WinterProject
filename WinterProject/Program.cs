Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Inventory inventory = new();
Item p = new Potion();
Item lP = new LargePotion();
Character player = new Player();

Text.PlayerInfo(player, inventory);

Console.ReadLine();

