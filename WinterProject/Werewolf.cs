public class Werewolf : Character
{
    public Werewolf()
    {
        _maxHp = 500;
        _hp = _maxHp;
        weapon = Armory.enemyWeapons[5];
    }
}
