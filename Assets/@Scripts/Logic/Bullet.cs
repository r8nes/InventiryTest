using System;

namespace InventoryTest.Logic.Abstract
{
    public class Bullet : IInventoryItem
    {
        public int Amount { get; set; }
        public int MaxItemInSlot { get; set; }
        public bool IsEquipped { get; set; }
        public Type Type => GetType();

        public Bullet(int maxItemInSlot)
        {
            MaxItemInSlot = maxItemInSlot;
        }

        public IInventoryItem Clone()
        {
            return new Bullet(MaxItemInSlot)
            {
                Amount = this.Amount
            };
        }
    }
}

