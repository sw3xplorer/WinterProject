using System.Security.Cryptography.X509Certificates;

public class Weapon : Item
{
    // All weapons get their values set in their constructor. Having a property for each variable is 
    // just too much lines of code.
    public int minDamage;
    public int maxDamage;
    public int critChance;
    public int critMultiplier;
    public int hitChance;
}
