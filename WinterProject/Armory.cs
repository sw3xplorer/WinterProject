public class Armory
{
    public static List<Weapon> enemyWeapons = new();
    List<Weapon> playerWeapons = new();

    public Armory()
    {
        // Enemy weapons
        enemyWeapons.Add(new() { name = "Wooden Club", minDamage = 1, maxDamage = 5, critChance = 5, critMultiplier = 2, hitChance = 80});
        enemyWeapons.Add(new() { name = "Spiked Bat", minDamage = 5, maxDamage = 10, critChance= 5, critMultiplier = 2, hitChance = 80 });
        enemyWeapons.Add(new() { name = "Bite", minDamage = 1, maxDamage = 3, critChance = 10, critMultiplier = 2, hitChance = 90 });
        enemyWeapons.Add(new() { name = "Stone Sword", minDamage = 10, maxDamage = 17, critChance = 10, critMultiplier = 2, hitChance = 85 });
        enemyWeapons.Add(new() { name = "Trunk", minDamage = 25, maxDamage = 30, critChance = 1, critMultiplier = 3, hitChance = 60 });
        enemyWeapons.Add(new() { name = "Werewolf Claw", minDamage = 38, maxDamage = 40, critChance = 20, critMultiplier = 3, hitChance = 95 });
    } 
    
}
