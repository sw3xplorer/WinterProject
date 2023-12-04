Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Inventory inventory = new();
Item p = new Potion();
Item lP = new LargePotion();
Player player = new Player();
Goblin goblin = new Goblin();
Character currEnemy = new Character();
// Instances can be assigned like variables if they are of the same type.
// currEnemy = goblin; as an example.




player.inventory.AddItem(p);
player.inventory.AddItem(p);
player.inventory.AddItem(p);
player.inventory.AddItem(lP);
player.inventory.AddItem(lP);


inventory.WriteConsumables();

Text.EnemyInfo(goblin);

Text.PlayerInfo(player, inventory);
player.Move();


player.Control(goblin);

Console.ReadLine();

