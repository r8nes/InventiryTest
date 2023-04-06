using System;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventoryItem
    {
        int Amount { get; set; }
        int MaxItemInSlot { get; set; }
        bool IsEquipped { get; set; }
        Type Type { get; }

        IInventoryItem Clone();
    }
}
