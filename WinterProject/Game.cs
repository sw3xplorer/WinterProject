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
            if(EnemyManager.enemies.Count() == 0)
            {
                player.Move();
            }
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

    public static void Shop(Player player, Armor armor)
    {
        // I could have done this without an int variable, but it is just a mess to read.
        int armorSold;
        int weaponSold;
        Random generator = new Random();
        armorSold = generator.Next(Armory.armors.Count());
        Console.WriteLine(Armory.armors[armorSold].AddedHp);
    }


}
