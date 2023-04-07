namespace InventoryTest.Logic.Abstract
{
    public interface IBuyable
    {
        int Price { get; }
        bool NeedToBuy { get; }
    }
}
