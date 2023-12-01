using System.Security.Cryptography.X509Certificates;

public class Game
{
    public static void InCombat(Player player, Character enemy)
    {
        while(player.Hp > 0 && enemy.Hp > 0)
        {
            player.Control();
            enemy.Attack();
        }
    }

}
