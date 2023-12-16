public class Bat : Character
{
    public Bat()
    {
        _name = "Bat";
        _maxHp = 10;
        _hp = _maxHp;
        weapon = new Bite();
    }
    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(11);
        player.Coins = _droppedCoins;
    }
}
