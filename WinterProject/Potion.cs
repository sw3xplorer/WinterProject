﻿public class Potion : Item
{
    public Potion()
    {
        Name = "Healing potion";
        weight = 3;
        cost = 50;
        _sellPrice = 20;
        effect = 75;
        _isConsumable = true;
    }

    public virtual void Consume(Player player)
    {
        player.Hp += effect;
        player.inventory.Weight -= weight;
        
    }
}
