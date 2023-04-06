namespace InventoryTest.Logic.Abstract
{
    public interface IInventoryItemState 
    {
        int Amount { get; set; }
        bool IsEquipped { get; set; }
    }
}
