namespace InventoryTest.Logic.Abstract
{
    public interface IPurchasable
    {
        int Price { get; set; }
        bool NeedToBuy { get; set; }
    }
}
