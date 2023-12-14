public class LargePotion : Item
{
    public LargePotion()
    {
        Name = "Large healing potion";
        weight = 4;
        cost = 100;
        sellPrice = 50;
        effect = 300;
        _isConsumable = true;
    }
}
