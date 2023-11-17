public class Goblin : Character
{
    public Goblin()
    {
        Random generator = new Random();
        _hp = 25;
        _maxHp = _hp;
        weapon = Armory.enemyWeapons[generator.Next(1)];
    }
}
