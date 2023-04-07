namespace InventoryTest.Logic.Abstract
{
    public interface IBuyable
    {
        int Price { get; set; }
        bool NeedToBuy { get; set; }
    }
}
