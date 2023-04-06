using System;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventoryItem
    {
        IInventoryItemInfo Info { get; }
        IInventoryItemState State { get; }
        Type Type { get; }

        IInventoryItem Clone();
    }
}
