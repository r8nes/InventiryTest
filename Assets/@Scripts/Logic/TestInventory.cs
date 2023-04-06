using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class TestInventory : MonoBehaviour
    {
        private IInventory _inventory;

        private void Awake()
        {
            var cap = 10;
            _inventory = new InventoryWithSlots(cap);
            Debug.Log($"Init, capacity: {cap}");
        }
    }
}
