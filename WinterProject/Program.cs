Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
Armory armory = new Armory();
Player player = new Player();
Bat bat = new Bat();
Goblin goblin = new Goblin();
Orc orc = new Orc();
Troll troll = new Troll();
Werewolf werewolf = new Werewolf();
Character currEnemy = new Character();

Console.WriteLine("You are ready to set off on some quests. Please chose a location to move to. You are at the shop right now.");
Task.Delay(5000).Wait();
Console.Clear();
player.Move();

Game.GameFunction(player, bat, goblin, orc, troll, werewolf, currEnemy);

// Instances can be assigned like variables if they are of the same type.
// currEnemy = goblin; as an example.

Console.ReadLine();