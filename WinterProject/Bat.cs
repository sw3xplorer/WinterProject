public class Bat : Character
{
    public Bat()
    {
        _maxHp = 10;
        _hp = _maxHp;
        weapon = Armory.enemyWeapons[2];
    }
}
