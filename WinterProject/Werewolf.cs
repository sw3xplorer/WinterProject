public class Werewolf : Character
{
    public Werewolf()
    {
        _name = "Werewolf";
        _maxHp = 500;
        _hp = _maxHp;
        weapon = new WerewolfClaw();
    }

    public override void OnDeath(Player player, Character enemy)
    {
        _droppedCoins = generator.Next(200, 501);
        player.Coins += _droppedCoins;
    }
}
