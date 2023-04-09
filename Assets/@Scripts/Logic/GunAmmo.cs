using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class GunAmmo : ItemBase, IAmmo
    {
        public int Power { get ; set ; }
        public override void Construct(IInventoryItemInfo info) => base.Construct(info);
        public void Action() => Debug.Log("Бдыщь");
    }
}