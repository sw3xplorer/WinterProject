public class IronSword : Weapon
{
    public IronSword()
    {
        Name = "Iron sword";
        minDamage = 7;
        maxDamage = 12;
        critChance = 15;
        critMultiplier = 2;
        hitChance = 85;
        _sellPrice = 40;
        cost = 100;
        weight = 8;
    }
}
