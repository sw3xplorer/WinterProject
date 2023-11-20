public class Werewolf : Character
{
    public Werewolf()
    {
        _maxHp = 500;
        _hp = _maxHp;
        weapon = new() { name = "Werewolf Claw", minDamage = 38, maxDamage = 40, critChance = 20, critMultiplier = 3, hitChance = 95 };
    }

    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(200, 501);
        player.Coins += _droppedCoins;
    }
}
