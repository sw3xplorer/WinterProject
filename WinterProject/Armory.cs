public class Armory
{
    // Just data on armor and weapons.
    public static List<Weapon> playerWeapons = new();
    public static List<Armor> armors = new();
    public static List<Item> potions = new();

    public Armory()
    {
        armors.Add(new BanditArmor {});
        armors.Add(new ChainmailArmor {});
        armors.Add(new HunterArmor {});
        playerWeapons.Add(new IronSword {});
        playerWeapons.Add(new SilverSword {});
        playerWeapons.Add(new SawCleaver {});
        potions.Add(new Potion());
        potions.Add(new LargePotion());
    } 
}
