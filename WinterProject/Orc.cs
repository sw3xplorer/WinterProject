public class Orc : Character
{
    public Orc()
    {
        maxHp = 100;
        hp = maxHp;
        weapon = Armory.enemyWeapons[3];
    }
}
