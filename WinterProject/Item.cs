public class Item
{
    public int weight;
    public int cost;
    protected int sellPrice;
    public int effect;
    string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
}
