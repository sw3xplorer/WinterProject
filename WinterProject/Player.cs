public class Player : Character
{
    Inventory inventory = new();
    public Player()
    {
        _maxHp = 200;
        _hp = _maxHp;

    }
}
