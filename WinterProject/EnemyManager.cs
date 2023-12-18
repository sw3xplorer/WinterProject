public class EnemyManager
{
    static Random generator = new Random();
    static int amount;
    static int type;
    public static Queue<Character> enemies = new(); 
    // Queue for enemies.
    public static void AddEnemy(Player player)
    {   
        // Define possible enemies based on location
        
        List<Character> possibleEnemies = new();
        if (player.Location == "Wilderness")
        {
            possibleEnemies.Add(new Bat());
            possibleEnemies.Add(new Goblin());
        }
        else
        {
            possibleEnemies.Add(new Orc());
            possibleEnemies.Add(new Troll());
        }
        // Define how many enemies.
        amount = generator.Next(1, 6);
        for (int i = 0; i < amount; i++)
        {
            // (There is a better way to make this)
            // (Problem was that it only created one instance, meaning that if there were say 2 goblins, they would share the HP value)
            // (So killing 1 goblin would kill all goblins at the same time)
            type = generator.Next(possibleEnemies.Count());

            // enemies.Enqueue(possibleEnemies[type]);

            if (type == 0 && player.Location == "Wilderness")
            {
                enemies.Enqueue(new Bat());
            }
            else if (type == 1 && player.Location == "Wilderness")
            {
                enemies.Enqueue(new Goblin());
            }
            else if (type == 0 && player.Location == "Howling Grotto")
            {
                enemies.Enqueue(new Orc());
            }
            else if (type == 1 && player.Location == "Howling Grotto")
            {
                enemies.Enqueue(new Troll());
            }
            
        }
        if (player.Location == "Howling Grotto")
        {
            enemies.Enqueue(new Werewolf());
        }
        
    }

    // Removes enemy from queue.
    public static void RemoveEnemy(Character enemy, Queue<Character> e)
    {
        if (enemy.Hp == 0)
        {
            e.Dequeue();
        }
    }

    // This is a test function. Unused in the actual game.
    public static void WriteQueue()
    {
       foreach(Character e in enemies)
        {
            Console.WriteLine(e.Name);
        }
    }
}
