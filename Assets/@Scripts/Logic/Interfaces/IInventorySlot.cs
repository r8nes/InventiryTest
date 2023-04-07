using System;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventorySlot
    {
        int Amount { get; }
        int Capacity { get; }

        bool IsFull { get; }
        bool IsEmpty { get; }

        bool NeedToBuy { get; set; }
        int Price { get; set; }
        Type ItemType { get; }
        IInventoryItem Item { get; }

        void SetItem(IInventoryItem item);
        void SetPurchaseData(IBuyable purchase);
        void Clear();
    }
}
