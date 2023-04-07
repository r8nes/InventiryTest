using System;

namespace InventoryTest.Logic.Abstract
{
    public class ItemBase : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        
        public Type Type => GetType();

        public ItemBase(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var cloneItem = new ItemBase(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }

    public class EquipmentBase : ItemBase
    {
        public EquipmentBase(IInventoryItemInfo info) : base(info)
        {
        }
    }

    public class RiffleAmmo : Ammo
    {
        public RiffleAmmo(IInventoryItemInfo info) : base(info)
        {
        }
    }

    public class GunAmmo : Ammo
    {
        public GunAmmo(IInventoryItemInfo info) : base(info)
        {
        }
    }

    public class Ammo : ItemBase
    {
        public Ammo(IInventoryItemInfo info) : base(info)
        {
        }
    }
}

