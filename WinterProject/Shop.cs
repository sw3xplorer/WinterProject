public class Shop
{
    int weaponSold;
    int armorSold;
    int potionSold;
    Random generator = new Random();
    public Shop()
    {
        armorSold = generator.Next(Armory.armors.Count());
        weaponSold = generator.Next(Armory.playerWeapons.Count());
        potionSold = generator.Next(2);
    }

    public void Purchase(Inventory inventory, Player player)
    {
        if(player.Choice == 0)
        {
            if(player.Coins - Armory.armors[armorSold].cost >= 0)
            {
                player.Coins -= Armory.armors[armorSold].cost;
                inventory.AddItem(Armory.armors[armorSold]);
                player.SetArmor(Armory.armors[armorSold]);
            }
            else
            {
                Console.SetCursorPosition(0, 35);
                Console.WriteLine("Not enough coins.");
                Task.Delay(1500).Wait();
            }
        }
        else if(player.Choice == 1)
        {
            if(player.Coins - Armory.playerWeapons[weaponSold].cost >= 0)
            {
                inventory.AddItem(Armory.playerWeapons[weaponSold]);
                player.Coins -= Armory.playerWeapons[weaponSold].cost;
                player.SetWeapon(Armory.playerWeapons[weaponSold]);
            }
            else
            {
                Console.SetCursorPosition(0, 35);
                Console.WriteLine("Not enough coins.");
                Task.Delay(1500).Wait();
            }
        }
        else
        {
            if(player.Coins - Armory.potions[potionSold].cost >= 0)
            {
                inventory.AddItem(Armory.potions[potionSold]);
                player.Coins -= Armory.potions[potionSold].cost;
            }
            else
            {
                Console.SetCursorPosition(0, 35);
                Console.WriteLine("Not enough coins.");
                Task.Delay(1500).Wait();
            }
        }
    }

    public void WriteItems()
    {
        // I could have done this without an int variable, but it is just a mess to read.
        // ARMOR

        Console.SetCursorPosition(1, 3);
        Console.WriteLine(Armory.armors[armorSold].Name);
        Console.SetCursorPosition(1, 4);
        Console.WriteLine($"Added HP: {Armory.armors[armorSold].AddedHp}");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine($"Weight: {Armory.armors[armorSold].weight}");
        Console.SetCursorPosition(1, 6);
        Console.WriteLine($"Price: {Armory.armors[armorSold].cost}");

        // WEAPON

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

        // POTION

        Console.SetCursorPosition(1, 17);
        Console.WriteLine(Armory.potions[potionSold].Name);
        Console.SetCursorPosition(1, 18);
        Console.WriteLine($"Price: {Armory.potions[potionSold].cost}");
        Console.SetCursorPosition(1, 19);
        Console.WriteLine($"Weight: {Armory.potions[potionSold].weight}");
        Console.SetCursorPosition(1, 20);
        Console.WriteLine($"Effect: {Armory.potions[potionSold].effect}");
    }
}
