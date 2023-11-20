public class Character
{
    // Protected is in between private and public. "Semi-public"
    protected Random generator = new Random();
    protected int _hp;
    protected int _maxHp;
    protected int _droppedCoins;
    protected int _coins;

    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if (_hp < 0) _hp = 0;
            if (_hp > _maxHp) _hp = _maxHp;
        }
    }
    public int MaxHp
    {
        get
        {
            return _maxHp;
        }
        set
        {
            _maxHp += value;
        }
    }

    public int Coins
    {
        get
        {
            return _droppedCoins;
        }
        set
        {
            _coins += value;
        }
    }

    protected Weapon weapon = new();

    protected virtual void Attack()
    {

    }
    public virtual void OnDeath(Player player, Character enemy)
    {
        player._coins += enemy._droppedCoins;
    }

}
