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

    public static void WriteItems()
    {
        // I could have done this without an int variable, but it is just a mess to read.
        int itemSold;
        Random generator = new Random();



        itemSold = generator.Next(Armory.armors.Count());
        Console.SetCursorPosition(1, 3);

        Console.WriteLine(Armory.armors[itemSold].Name);
        Console.SetCursorPosition(1, 4);
        Console.WriteLine($"Added HP: {Armory.armors[itemSold].AddedHp}");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine($"Weight: {Armory.armors[itemSold].weight}");
        Console.SetCursorPosition(1, 6);
        Console.WriteLine($"Price: {Armory.armors[itemSold].cost}");

        itemSold = generator.Next(Armory.playerWeapons.Count());
        Console.SetCursorPosition(1, 8);
        Console.WriteLine(Armory.playerWeapons[itemSold].Name);

        Console.SetCursorPosition(1, 9);
        Console.WriteLine($"Min damage: {Armory.playerWeapons[itemSold].minDamage}");
        Console.SetCursorPosition(1, 10);
        Console.WriteLine($"Max damage: {Armory.playerWeapons[itemSold].maxDamage}");
        Console.SetCursorPosition(1, 11);
        Console.WriteLine($"Weight: {Armory.playerWeapons[itemSold].weight}");
        Console.SetCursorPosition(1, 12);
        Console.WriteLine($"Price: {Armory.playerWeapons[itemSold].cost}");

        Console.SetCursorPosition(1,13);
        if(generator.Next(1) == 0)
        {
            Console.WriteLine(Armory.potions[0].Name);
            Console.SetCursorPosition(1,14);
            Console.WriteLine(Armory.potions[0].cost);
            Console.SetCursorPosition(1,15);
            Console.WriteLine(Armory.potions[0].weight);
            Console.SetCursorPosition(1,16);
            Console.WriteLine(Armory.potions[0].effect);
        }

    }


}
