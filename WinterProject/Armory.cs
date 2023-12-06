public class Armory
{
    public static List<Weapon> playerWeapons = new();
    public static List<Armor> armors = new();

    Armory()
    {
        armors.Add(new BanditArmor {});
        armors.Add(new ChainmailArmor {});
        armors.Add(new HunterArmor {});
    } 
    
}
