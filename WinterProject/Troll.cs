public class Troll : Character
{
    public Troll()
    {
        _maxHp = 250;
        _hp = _maxHp;
        weapon = new() { name = "Trunk", minDamage = 25, maxDamage = 30, critChance = 1, critMultiplier = 3, hitChance = 60 };
    }
    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(100, 151);
        player.Coins += _droppedCoins;
    }
}
