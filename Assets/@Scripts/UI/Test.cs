using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Test
    {
        private InventoryItemInfo _bullet1;
        private UIInventorySlot[] _uiSlots;

        public InventoryWithSlots Inventory { get; }

        public Test(InventoryItemInfo info1, UIInventorySlot[] slots) 
        {
            _bullet1 = info1;
            _uiSlots = slots;

            Inventory = new InventoryWithSlots(30);
            Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        }

        public void FillSlots() 
        {
            var allSlots = Inventory.GetAllSlots();
            var availableSlots = new List<IInventorySlot>(allSlots);
            var filledSlots = 5;

            SetupUI(Inventory);

            for (int i = 0; i < filledSlots; i++)
            {
                var filledSlot = AddRandomBullet1(availableSlots);
                availableSlots.Remove(filledSlot);
            }

            SetupUI(Inventory);
        }

        private void SetupUI(InventoryWithSlots inventory) 
        {
            var allSlots = inventory.GetAllSlots();
            var allSlotsCount = allSlots.Length;

            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];

                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        #region Refactoring

        private IInventorySlot AddRandomBullet1(List<IInventorySlot> slots)
        {
            var randSlotIndex = Random.Range(0, slots.Count);
            var randSlot = slots[randSlotIndex];
            var randCount = Random.Range(1, 4);
            var bullet1 = new RiffleAmmo(_bullet1);

            bullet1.State.Amount = randCount;
            Inventory.TryToAddToSlot(this, randSlot, bullet1);

            return randSlot;
        }

        #endregion

        private void OnInventoryStateChanged(object sender) 
        {
            foreach (var slot in _uiSlots)
            {
                slot.Refresh();
            }
        }
    }
}