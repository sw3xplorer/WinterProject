public class Text
{
    public static void PlayerInfo(Player player, Inventory inventory)
    {
        ClearArea(0, 0, 70, 1);
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"HP: {player.Hp}/{player.MaxHp}");
        Console.SetCursorPosition(20, 0);
        Console.WriteLine($"Coins: {player.Coins}");
        Console.SetCursorPosition(40, 0);
        Console.WriteLine($"Weight: {player.inventory.Weight}/{player.inventory.MaxWeight}");

        ClearArea((int)Console.LargestWindowWidth - 40, 40, (int)Console.LargestWindowWidth - 5, 42);
        Console.SetCursorPosition((int)Console.LargestWindowWidth - 40, 40);
        Console.WriteLine($"Eqquiped armor: {player.Armor.Name}");
        Console.SetCursorPosition((int)Console.LargestWindowWidth - 40, 41);
        Console.WriteLine($"Eqquiped weapon: {player.Weapon.Name}");
    }

    public static void EnemyInfo(Character enemy)
    {
        ClearArea(120, 0, 140, 1);
        Console.SetCursorPosition(120, 0);
        Console.WriteLine($"{enemy.Name} HP: {enemy.Hp}/{enemy.MaxHp}");

    }





    public static void ClearArea(int startX, int startY, int endX, int endY)
    {
        for (int i = startX; i < endX; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                Console.SetCursorPosition(i, j);
                Console.Write(" ");

            }
        }
    }
}
