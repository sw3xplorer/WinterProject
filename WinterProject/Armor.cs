public class Armor : Item
{
    protected int _addedHp;
    protected bool _isEquipped;

    public int AddedHp
    {
        get
        {
            return _addedHp;
        }
        private set
        {

        }
    }
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
