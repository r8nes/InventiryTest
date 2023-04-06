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
         
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddRandomItem();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RemoveRandomItem();
            }
        }

        private void AddRandomItem()
        {
            var rand = Random.Range(1,5);
            var bullet = new Bullet(5)
            {
                Amount = rand
            };
            _inventory.TryToAdd(this, bullet);
        }

        private void RemoveRandomItem()
        {
            var rand = Random.Range(1,5);
            _inventory.Remove(this, typeof(Item), rand);
        }
    }
}
