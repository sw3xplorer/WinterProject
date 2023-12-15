public class Game
{
    public static void InCombat(Player player, Character enemy, Armor armor, Potion potion)
    {

        while (player.Hp > 0 && enemy.Hp > 0)
        {
            player.Control(enemy);
            enemy.Attack(player);
        }
        if (enemy.Hp <= 0)
        {
            enemy.OnDeath(player, enemy);
            if (EnemyManager.enemies.Count() == 0)
            {
                player.Move();
            }
            if (player.Location == "Shop")
            {
                player.Shop();
            }
        }
        else if (player.Hp <= 0)
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
