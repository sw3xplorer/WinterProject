public class Troll : Character
{
    public Troll()
    {
        _maxHp = 250;
        _hp = _maxHp;
        weapon = Armory.enemyWeapons[4];
    }
}
