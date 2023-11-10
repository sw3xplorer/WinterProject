using System.Diagnostics.Contracts;

public class Player : Character
{
    public Inventory inventory = new();
    public Player()
    {
        maxHp = 200;
        hp = maxHp;
        
    }
}
