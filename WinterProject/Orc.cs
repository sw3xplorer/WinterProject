public class Orc : Character
{
    public Orc()
    {
        _maxHp = 100;
        _hp = _maxHp;
        weapon = Armory.enemyWeapons[3];
    }
}
