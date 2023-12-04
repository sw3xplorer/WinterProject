public class Game
{
    public static void InCombat(Player player, Character enemy)
    {
        while(player.Hp > 0 && enemy.Hp > 0)
        {
            player.Control(enemy);
            enemy.Attack(player);
        }
        if(enemy.Hp <= 0)
        {
            enemy.OnDeath(player, enemy);
            player.Move();
        }
        else if(player.Hp <= 0)
        {
            Console.Clear();
            Console.WriteLine(@"___  _ ____  _       ____  _  _____ ____ 
\  \///  _ \/ \ /\  /  _ \/ \/  __//  _ \
 \  / | / \|| | ||  | | \|| ||  \  | | \|
 / /  | \_/|| \_/|  | |_/|| ||  /_ | |_/|
/_/   \____/\____/  \____/\_/\____\\____/
                                         ");
            Task.Delay(3000).Wait();
            Environment.Exit(0);
        }
    }

}
