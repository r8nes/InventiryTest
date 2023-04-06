using System;

namespace InventoryTest.Logic.Abstract
{
    public class BulletX : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        
        // TODO: Change to enum type
        public Type Type => GetType();

        public BulletX(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var cloneItem = new BulletX(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }

    public class BulletY : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }

        public Type Type => GetType();

        public BulletY(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var cloneItem = new BulletY(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }
}

