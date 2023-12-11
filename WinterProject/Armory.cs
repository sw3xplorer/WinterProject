public class Armory
{
    public static List<Weapon> playerWeapons = new();
    public static List<Armor> armors = new();

    public Armory()
    {
        armors.Add(new BanditArmor {});
        armors.Add(new ChainmailArmor {});
        armors.Add(new HunterArmor {});
        playerWeapons.Add(new IronSword {});
        playerWeapons.Add(new SilverSword {});
        playerWeapons.Add(new SawCleaver {});
    } 

    
}
