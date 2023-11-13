public class Werewolf : Character
{
    public Werewolf()
    {
        maxHp = 500;
        hp = maxHp;
        weapon = Armory.enemyWeapons[5];
    }
}
