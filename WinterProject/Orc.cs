public class Orc : Character
{
    public Orc()
    {
        _name = "Orc";
        _maxHp = 100;
        _hp = _maxHp;
        weapon = new() { name = "Stone Sword", minDamage = 10, maxDamage = 17, critChance = 10, critMultiplier = 2, hitChance = 85 };
    }

    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(25, 91);
        player.Coins += _droppedCoins;
    }
}
