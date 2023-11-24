public class Potion : Item, IConsumable
{
    public Potion()
    {
        name = "Healing potion";
        weight = 3;
        cost = 50;
        sellPrice = 20;
        effect = 75;
    }

    public virtual void Consume(Character character)
    {
        character.Hp += effect;
    }
}
