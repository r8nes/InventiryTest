using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class GunAmmo : ItemBase, IAmmo
    {
        public int Power { get ; set ; }

        public void Action() => Debug.Log("Бдыщь");
    }
}

