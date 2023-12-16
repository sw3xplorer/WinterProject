public class Game
{
    public static void GameFunction(Player player, Bat bat, Goblin goblin, Orc orc, Troll troll, Werewolf werewolf, Character currentEnemy)
    {
        while (true)
        {
            if (player.Location != "Shop")
            {
                // Current bug: When two enemies of the same type follow in a queue, enemy hp does not reset.
                // Solution: Create a new instance for each enemy in EnemyManager.

                // Text.ClearArea(0, 1, 10, 10);
                // EnemyManager.enemies.Clear();
                EnemyManager.AddEnemy(player);
                currentEnemy = EnemyManager.enemies.Peek();
                Text.PlayerInfo(player, player.inventory);
                Text.EnemyInfo(currentEnemy);
                while (player.Hp > 0 && currentEnemy.Hp > 0 && EnemyManager.enemies.Count() != 0)
                {
                    while (player.Hp > 0 && currentEnemy.Hp > 0)
                    {
                        player.Control(currentEnemy);
                        
                        if(currentEnemy.Hp > 0) currentEnemy.Attack(player);
                        Text.PlayerInfo(player, player.inventory);
                        Text.EnemyInfo(currentEnemy);
                        if (currentEnemy.Hp <= 0)
                        {
                            currentEnemy.OnDeath(player, currentEnemy);
                            EnemyManager.enemies.Dequeue();
                            if (EnemyManager.enemies.Count() != 0)
                            {
                                currentEnemy = EnemyManager.enemies.Peek();
                                Text.EnemyInfo(currentEnemy);
                            }
                        }
                    }
                }
                if (EnemyManager.enemies.Count() == 0)
                {
                    Text.ClearArea(0, 1, 10, 10);
                    player.Move();
                }
            }

            else if (player.Location == "Shop")
            {
                player.Shop();
            }

            if (player.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine(@"__   _______ _   _  ______ _____ ___________ 
\ \ / /  _  | | | | |  _  \_   _|  ___|  _  \
 \ V /| | | | | | | | | | | | | | |__ | | | |
  \ / | | | | | | | | | | | | | |  __|| | | |
  | | \ \_/ / |_| | | |/ / _| |_| |___| |/ / 
  \_/  \___/ \___/  |___/  \___/\____/|___/  
                                             ");

                Console.SetCursorPosition(0, 20);
                Console.WriteLine(@" _____     _ _   _                   
|  ___|   (_) | (_)                  
| |____  ___| |_ _ _ __   __ _       
|  __\ \/ / | __| | '_ \ / _` |      
| |___>  <| | |_| | | | | (_| |_ _ _ 
\____/_/\_\_|\__|_|_| |_|\__, (_|_|_)
                          __/ |      
                         |___/       ");
                Task.Delay(3000).Wait();
                Environment.Exit(0);
            }
        }
    }

}
