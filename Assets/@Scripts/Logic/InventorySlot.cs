using System;

namespace InventoryTest.Logic.Abstract
{
    public class InventorySlot : IInventorySlot, IPurchasable
    {
        public int Amount => IsEmpty ? 0 : Item.State.Amount;
        public int Capacity { get; private set; }
        public bool IsFull => !IsEmpty && Amount == Capacity;
        public bool IsEmpty => Item == null;
        public Type ItemType => Item.Type;
        public IInventoryItem Item { get; private set; }
        public bool NeedToBuy { get; set;}
        public int Price { get ; set; }

        public void SetItem(IInventoryItem item) 
        {
            if (!IsEmpty) return;

            Item = item;
            Capacity = item.Info.MaxItemInSlot;
        }

        public void SetPurchaseData(IPurchasable purchase) 
        {
            NeedToBuy = purchase.NeedToBuy;
            Price = purchase.Price;
        }

        public void Clear() 
        {
            if (IsEmpty) return;

            Item.State.Amount = 0;
            Item = null;
        }
    }
}