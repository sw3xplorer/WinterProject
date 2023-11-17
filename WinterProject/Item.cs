public class Item
{
    protected int weight;
    protected int cost;
    protected int sellPrice;
    protected int effect;
    public string name = "";

    public virtual void Consume(Character character)
    {
        character.Hp += effect;
    }
}
