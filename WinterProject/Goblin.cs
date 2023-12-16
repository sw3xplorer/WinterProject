public class Goblin : Character
{
    public Goblin()
    {
        // Random generator = new Random();
        _name = "Goblin";
        _hp = 25;
        _maxHp = _hp;
        if (generator.Next(1) == 1)
        {
            weapon = new WoodenClub();
        }
        else
        {
            weapon = new SpikedClub();
        }
    }

    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(10, 26);
        player.Coins = _droppedCoins;
    }
}
