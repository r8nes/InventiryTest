using System;

namespace InventoryTest.Logic.Abstract
{
    public class Item : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        
        // TODO: Change to enum type
        public Type Type => GetType();

        public Item(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var cloneItem = new Item(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }
}

