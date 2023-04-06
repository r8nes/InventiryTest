using System;

namespace InventoryTest.Logic.Abstract
{
    public class InventorySlot : IInventorySlot
    {
        public int Amount => IsEmpty ? 0 : Item.Amount;
        public int Capacity { get; private set; }
        public bool IsFull => Amount == Capacity;
        public bool IsEmpty => Item == null;
        public Type ItemType => Item.Type;
        public IInventoryItem Item { get; private set; } 

        public void SetItem(IInventoryItem item) 
        {
            if (!IsEmpty) return;

            Item = item;
            Capacity = item.MaxItemInSlot;
        }

        public void Clear() 
        {
            if (IsEmpty) return;

            Item.Amount = 0;
            Item = null;
        }
    }
}