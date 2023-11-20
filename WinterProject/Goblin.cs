public class Goblin : Character
{
    public Goblin()
    {
        // Random generator = new Random();
        _hp = 25;
        _maxHp = _hp;
        if(generator.Next(1) == 1)
        {
            weapon = new() { name = "Wooden Club", minDamage = 1, maxDamage = 5, critChance = 5, critMultiplier = 2, hitChance = 80};
        }
        else
        {
            weapon = new() { name = "Spiked Bat", minDamage = 5, maxDamage = 10, critChance= 5, critMultiplier = 2, hitChance = 80 };
        }
    }

    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(10, 26);
        player.Coins += _droppedCoins;
    }
}
