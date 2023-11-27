using System.Runtime.ConstrainedExecution;

public class EnemyManager
{
    public static Queue<Character> enemies = new();
    public static void AddEnemy(Character enemy, Queue<Character> e)
    {   
        e.Enqueue(enemy);
    }

    public static void WriteQueue()
    {
       foreach(Character e in enemies)
        {
            Console.WriteLine(e.Name);
        }
    }
}
