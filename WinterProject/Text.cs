public class Text
{
    public static void Intro()
    {
        // Waking up
        Console.WriteLine("Hey, you. You're finally awake.");
        Console.WriteLine("I'm surprised that you managed to sleep through the night.");
        Console.WriteLine("Never seen a fellow being able to rest while the village got attacked.");
        Console.WriteLine("But you can't rest anymore. The hunting guild is looking for you.");
        Console.WriteLine("They said that you have experience of hunting down creatures and monsters, so they wish to recruit you for some commisions.");
        Console.WriteLine("No time to waste, let's go.");

        // Hunting guild
        Console.WriteLine("You and the stranger walk over to the hunting guild. The chief was already waiting for the both of you.");
        Console.WriteLine("Greetings. I assume you have been told about what happened last night. We need your expertise in slaying some creatures.");
        Console.WriteLine("We can't allow our village to keep being attacked. Let's get you ready.");
        Console.WriteLine("The chief gives you some equipment. A sword, some food and potions.");
        // You gained said items. Write code for this.
        Console.WriteLine("These provisions should be enough to get you started. We will pay you for your efforts.");
        Console.WriteLine("You may spend your rewards at our armory for better equipment.");
        Console.WriteLine("For your first comission, we have had reports of goblins outside our village, around where the lumberjacks work.");
        Console.WriteLine("Go and make sure that area is safe. Off you go now.");
        Console.WriteLine("You head out of the guild and towards the woods.");

    }
    public static void PlayerInfo(Character player)
    {
        Console.WriteLine($"HP: {player.Hp}/{player.MaxHp}");
        Console.SetCursorPosition(20,0);
        Console.WriteLine($"Coins: {player.Coins}");
        
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
