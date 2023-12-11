public class Troll : Character
{
    public Troll()
    {
        _name = "Troll";
        _maxHp = 250;
        _hp = _maxHp;
        weapon = new Trunk();
    }
    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(100, 151);
        player.Coins += _droppedCoins;
    }
}
