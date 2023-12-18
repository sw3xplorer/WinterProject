public class Character
{
    // Protected is in between private and public. "Semi-public"

    // General declaration of variables which characters will use
    protected Random generator = new Random();
    protected int _hp;
    protected int _maxHp;
    protected int _droppedCoins;
    protected int _coins;
    protected string _name;

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
            return _coins;
        }
        set
        {
            _coins += value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {

        }
    }

    protected Weapon weapon = new();
    protected Armor armor = new();

// Attack function which can be adapted to how characters behave
    public virtual void Attack(Character target)
    {
        int damage; 
        damage = generator.Next(weapon.minDamage, weapon.maxDamage);
        if (generator.Next(100) <= weapon.critChance)
        {
            damage = damage * weapon.critMultiplier;
        }
        if (generator.Next(100) <= weapon.hitChance)
        {
            target.Hp -= damage;
        }
    }
    // What enemies do on death, mainly drop coins
    public virtual void OnDeath(Player player, Character enemy)
    {
        player.Coins = enemy._droppedCoins;
    }

    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
    public void SetArmor(Armor newArmor)
    {
        armor = newArmor;
        MaxHp = newArmor.AddedHp;
    }
    
    
}
