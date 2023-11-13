public class Character
{
    // Protected is in between private and public. "Semi-public"
    protected int hp;
    protected int maxHp;

    public Weapon weapon = new();

    protected virtual void Attack()
    {
        
    }
    
}
