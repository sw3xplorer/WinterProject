using System.Security.Cryptography.X509Certificates;

public class Weapon : Item
{
    public int minDamage;
    public int maxDamage;
    protected int critChance;
    protected int critMultiplier;
    protected int hitChance;
}
