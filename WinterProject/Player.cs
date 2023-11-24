public class Player : Character
{
    Inventory inventory = new();
    int coins = 0;
    int _choice = 0;
    bool _confirmAction = false;
    bool _confirmItem = false;
    public Player()
    {
        _maxHp = 200;
        _hp = _maxHp;

    }

    // Player can either attack or use item.
    public void Control()
    {
        Console.SetCursorPosition(1, 3);
        Console.WriteLine("Attack");
        Console.SetCursorPosition(1, 5);
        Console.WriteLine("Item");
        while (!_confirmAction)
        {
            if (_choice >= 0 && _choice <= 1)
            {
                Console.SetCursorPosition(0, 3 + _choice * 2);
                Console.WriteLine(">");
            }
            
            var key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.DownArrow && _choice < 1)
            {
                _choice++;
                Console.SetCursorPosition(0, 3 + ((_choice -1) * 2));
                Console.WriteLine(" ");
            }
            else if(key.Key == ConsoleKey.UpArrow && _choice > 0)
            {
                _choice--;
                Console.SetCursorPosition(0, 3 + ((_choice + 1)* 2));
                Console.WriteLine(" ");
            }
            else if(key.Key == ConsoleKey.Enter)
            {
                _confirmAction = true;
            }
            if(_choice == 1 && _confirmAction)
            {

            }
        }
    }
}
