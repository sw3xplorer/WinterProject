public class Orc : Character
{

    public Orc()
    {
        _name = "Orc";
        _maxHp = 100;
        _hp = _maxHp;
        weapon = new StoneSword();
    }

    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(25, 91);
        player.Coins += _droppedCoins;
    }
}
