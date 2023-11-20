public class Player : Character
{
    Inventory inventory = new();
    int coins = 0;
    public Player()
    {
        _maxHp = 200;
        _hp = _maxHp;

    }
}
