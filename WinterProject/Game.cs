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
        int weaponSold;
        int armorSold;
        int potionSold;
        Random generator = new Random();

        armorSold = generator.Next(Armory.armors.Count());
        Console.SetCursorPosition(1, 3);

        Console.WriteLine(Armory.armors[armorSold].Name);
        Console.SetCursorPosition(1, 4);
        Console.WriteLine($"Added HP: {Armory.armors[armorSold].AddedHp}");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine($"Weight: {Armory.armors[armorSold].weight}");
        Console.SetCursorPosition(1, 6);
        Console.WriteLine($"Price: {Armory.armors[armorSold].cost}");

        weaponSold = generator.Next(Armory.playerWeapons.Count());
        Console.SetCursorPosition(1, 10);
        Console.WriteLine(Armory.playerWeapons[weaponSold].Name);

        Console.SetCursorPosition(1, 11);
        Console.WriteLine($"Min damage: {Armory.playerWeapons[weaponSold].minDamage}");
        Console.SetCursorPosition(1, 12);
        Console.WriteLine($"Max damage: {Armory.playerWeapons[weaponSold].maxDamage}");
        Console.SetCursorPosition(1, 13);
        Console.WriteLine($"Weight: {Armory.playerWeapons[weaponSold].weight}");
        Console.SetCursorPosition(1, 14);
        Console.WriteLine($"Price: {Armory.playerWeapons[weaponSold].cost}");

        Console.SetCursorPosition(1, 17);
        potionSold = generator.Next(2);

        Console.WriteLine(Armory.potions[potionSold].Name);
        Console.SetCursorPosition(1, 18);
        Console.WriteLine($"Price: {Armory.potions[potionSold].cost}");
        Console.SetCursorPosition(1, 19);
        Console.WriteLine($"Weight: {Armory.potions[potionSold].weight}");
        Console.SetCursorPosition(1, 20);
        Console.WriteLine($"Effect: {Armory.potions[potionSold].effect}");
    }

}
