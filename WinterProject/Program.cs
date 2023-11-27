Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Inventory inventory = new();
Item p = new Potion();
Item lP = new LargePotion();
Player player = new Player();


player.inventory.AddItem(p);
player.inventory.AddItem(p);
player.inventory.AddItem(p);
player.inventory.AddItem(lP);
player.inventory.AddItem(lP);


inventory.WriteConsumables();

Text.PlayerInfo(player, inventory);

player.Control();

Console.ReadLine();

