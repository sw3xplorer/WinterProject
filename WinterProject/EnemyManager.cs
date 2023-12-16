using System.Runtime.ConstrainedExecution;

public class EnemyManager
{
    static Random generator = new Random();
    static int amount;
    static int type;
    public static Queue<Character> enemies = new();
    
    public static void AddEnemy(Player player)
    {   
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

        amount = generator.Next(1, 6);
        for (int i = 0; i < amount; i++)
        {
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
    public static void RemoveEnemy(Character enemy, Queue<Character> e)
    {
        if (enemy.Hp == 0)
        {
            e.Dequeue();
        }
    }

    public static void WriteQueue()
    {
       foreach(Character e in enemies)
        {
            Console.WriteLine(e.Name);
        }
    }
}
