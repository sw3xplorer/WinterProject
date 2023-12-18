public class Item
{

    protected bool _isConsumable;
    public bool IsConsumable
    {
        get
        {
            return _isConsumable;
        }
        private set
        {

        }
    }
    // Some public variables that can be edited from elsewhere.
    // (Should be in properties instead, fix later)
    public int weight;
    public int cost;
    protected int _sellPrice;
    public int SellPrice
    {
        get
        {
            return _sellPrice;
        }
        private set
        {
            
        }
    }
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
