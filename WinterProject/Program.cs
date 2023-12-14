Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Inventory inventory = new();
Armory a = new();
Armor armor = new();
ChainmailArmor chainmailArmor = new();
IronSword ironSword = new();
SawCleaver sawCleaver = new();
Item p = new Potion();
Item lP = new LargePotion();
Player player = new Player();
Goblin goblin = new Goblin();
Potion potion = new Potion();
Character currEnemy = new Character();
// Instances can be assigned like variables if they are of the same type.
// currEnemy = goblin; as an example.


player.inventory.AddItem(p);
player.inventory.AddItem(p);
player.inventory.AddItem(p);
player.inventory.AddItem(lP);
player.inventory.AddItem(lP);
player.inventory.AddItem(ironSword);
player.inventory.AddItem(chainmailArmor);


// Text.EnemyInfo(goblin);
// Text.PlayerInfo(player, inventory);
player.Control(goblin);

// player.Shop();

// player.Move();
// Game.WriteInventory(player);





Console.ReadLine();

