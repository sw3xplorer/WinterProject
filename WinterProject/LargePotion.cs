public class LargePotion : Potion
{
    public LargePotion()
    {
        Name = "Large healing potion";
        weight = 4;
        cost = 100;
        _sellPrice = 50;
        effect = 300;
        _isConsumable = true;
    }
}
