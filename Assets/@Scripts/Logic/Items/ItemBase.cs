using System;

namespace InventoryTest.Logic.Abstract
{
    public class ItemBase : IInventoryItem
    {
        public IInventoryItemInfo Info { get; private set; }
        public IInventoryItemState State { get; private set; }
        
        public Type Type => GetType();

        public virtual void Construct(IInventoryItemInfo info) 
        {
            Info = info;
            State = new InventoryItemState();
        }

        public virtual IInventoryItem Clone()
        {
            ItemBase cloneItem = new ItemBase();
            
            cloneItem.Construct(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }
}

