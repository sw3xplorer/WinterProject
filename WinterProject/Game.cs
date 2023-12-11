public class Game
{
    public static void InCombat(Player player, Character enemy, Armor armor, Potion potion)
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
            if(player.Location == "Shop")
            {
                player.Shop();
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

    public static void WriteItems()
    {
        // I could have done this without an int variable, but it is just a mess to read.
        int armorSold;
        int weaponSold;
        Random generator = new Random();



        armorSold = generator.Next(Armory.armors.Count());
        Console.WriteLine(Armory.armors[armorSold].Name);
        Console.WriteLine($"Added HP: {Armory.armors[armorSold].AddedHp}");
        Console.WriteLine($"Added HP: {Armory.armors[armorSold].weight}");
        Console.WriteLine($"Price: {Armory.armors[armorSold].cost}");

        weaponSold = generator.Next(Armory.playerWeapons.Count());
        Console.WriteLine($"\n{Armory.playerWeapons[weaponSold].Name}");
        Console.WriteLine($"Min damage: {Armory.playerWeapons[weaponSold].minDamage}");
        Console.WriteLine($"Max damage: {Armory.playerWeapons[weaponSold].maxDamage}");
        Console.WriteLine($"Max damage: {Armory.playerWeapons[weaponSold].weight}");
        Console.WriteLine($"Price: {Armory.playerWeapons[weaponSold].cost}");
    }


}
