using System;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventorySlot 
    {
        int Amount { get; }
        int Capacity { get; }
 
        bool IsFull { get; }
        bool IsEmpty { get; }

        Type ItemType { get; }    
        IInventoryItem Item { get; }
        IBuyable PurchaseInfo { get; }

        void SetItem(IInventoryItem item);
        void Clear();
    }
}
