using System;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class ItemBase : IInventoryItem
    {
        public IInventoryItemInfo Info { get; private set; }
        public IInventoryItemState State { get; private set; }
        
        public Type Type => GetType();

        public  virtual void Construct(IInventoryItemInfo info) 
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            ItemBase cloneItem = new ItemBase();
            
            cloneItem.Construct(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }

    public class RiffleAmmo : ItemBase, IAmmo
    {
        public int Power { get ; set; }

        public override void Construct(IInventoryItemInfo info)
        {
            base.Construct(info);
        }

        public void Action() => Debug.Log("Пиу");
    }

    public class GunAmmo : ItemBase, IAmmo
    {
        public int Power { get ; set ; }

        public void Action() => Debug.Log("Бдыщь");
    }
}

