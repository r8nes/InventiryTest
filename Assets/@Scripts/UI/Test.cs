using System.Collections.Generic;
using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Test
    {
        // TODO вынести в SO
        private const int SLOT_CAPACITY = 30;

        private IFacade _facade;
        private AmmoConfig _ammoConfig;
        private EquimpentConfig _equipmentConfig;

        private UIInventorySlot[] _uiSlots;

        public InventoryWithSlots Inventory { get; }

        public Test(AmmoConfig ammoConfig, EquimpentConfig equipmentConfig, UIInventorySlot[] slots, IFacade facade) 
        {
            _ammoConfig = ammoConfig;
            _equipmentConfig = equipmentConfig;
            _uiSlots = slots;
            _facade = facade;

            Inventory = new InventoryWithSlots(SLOT_CAPACITY);
            Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        }

        public void UpdateInventory() 
        {
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

        //private IInventorySlot AddRandomBullet1(List<IInventorySlot> slots)
        //{
        //    var randSlotIndex = Random.Range(0, slots.Count);
        //    var randSlot = slots[randSlotIndex];
        //    var randCount = Random.Range(1, 4);
        //    var bullet1 = new RiffleAmmo(_bullet1);

        //    bullet1.State.Amount = randCount;
        //    Inventory.TryToAddToSlot(this, randSlot, bullet1);

        //    return randSlot;
        //}

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