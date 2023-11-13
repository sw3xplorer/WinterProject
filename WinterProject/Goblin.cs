public class Goblin : Character
{
    public Goblin()
    {
        Random generator = new Random();
        hp = 25;
        maxHp = hp;
        weapon = Armory.enemyWeapons[generator.Next(1)];
    }
}
