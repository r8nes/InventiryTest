using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class RiffleAmmo : ItemBase, IAmmo
    {
        public int Power { get ; set; }

        public override void Construct(IInventoryItemInfo info) => base.Construct(info);

        public override IInventoryItem Clone()
        {
            RiffleAmmo cloneItem = new RiffleAmmo();

            cloneItem.Construct(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }

        public void Action() => Debug.Log("Пиу");
    }
}