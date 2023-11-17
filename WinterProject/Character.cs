public class Character
{
    // Protected is in between private and public. "Semi-public"
    protected int _hp;
    protected int _maxHp;

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

    protected Weapon weapon = new();

    protected virtual void Attack()
    {

    }

}
