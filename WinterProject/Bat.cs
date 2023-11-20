public class Bat : Character
{
    public Bat()
    {
        _maxHp = 10;
        _hp = _maxHp;
        weapon = Armory.enemyWeapons[2];
        weapon = new() { name = "Bite", minDamage = 1, maxDamage = 3, critChance = 10, critMultiplier = 2, hitChance = 90 };
    }
    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(11);
        player.Coins += _droppedCoins;
    }
}
