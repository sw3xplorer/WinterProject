public class Armor : Item
{
    protected int _addedHp;
    protected bool _isEquipped;

    public bool Equipped 
    {
       get
       {
        return _isEquipped;
       }
       set
       {
        if(_isEquipped == true);
       } 
    }
}
