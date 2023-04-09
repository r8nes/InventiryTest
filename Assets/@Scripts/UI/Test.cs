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

        private IStaticDataService _staticData;

        private UIInventorySlot[] _uiSlots;

        private List<IInventoryItem> Ammos = new List<IInventoryItem>(5);

        public InventoryWithSlots Inventory { get; }

        public Test(UIInventorySlot[] slots, IFacade facade, IStaticDataService staticData)
        {
            _staticData = staticData;
            _uiSlots = slots;

            _facade = facade;
            _facade.Warm();

            Inventory = new InventoryWithSlots(SLOT_CAPACITY);
            Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;

            SetUpInventory();
            SetupUI(Inventory);
        }

        public void AddAmmoItem(int amount)
        {
            IInventorySlot[] inventorySlots = Inventory.GetAllSlots();
            List<IInventorySlot> availableSlots = new List<IInventorySlot>(inventorySlots);

            for (int i = 0; i < Ammos.Count; i++)
            {
                var filledSlot = AddItem(availableSlots, Ammos[i], amount);
                availableSlots.Remove(filledSlot);
            }
        }

        private IInventorySlot AddItem(List<IInventorySlot> slots, IInventoryItem item, int amount)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (Inventory.CheckSlot(slots[i]))
                {
                    item.State.Amount = amount;
                    Inventory.TryToAddToSlot(this, slots[i], item);

                    return slots[i];
                }
            }

            return null;
        }

        private void SetUpInventory()
        {
            InitAmmoConfig(out AmmoConfig riffleData, out AmmoConfig gunData);
            InitAmmo(out RiffleAmmo riffleAmmo, out GunAmmo gunAmmo);

            riffleAmmo.Construct(riffleData);
            gunAmmo.Construct(gunData);

            Ammos.Add(riffleAmmo);
            Ammos.Add(gunAmmo);
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

        private void InitAmmo(out RiffleAmmo riffleAmmo, out GunAmmo gunAmmo)
        {
            riffleAmmo = _facade.GetAmmo<RiffleAmmo>();
            gunAmmo = _facade.GetAmmo<GunAmmo>();
        }

        private void InitAmmoConfig(out AmmoConfig riffleData, out AmmoConfig gunData)
        {
            riffleData = (AmmoConfig)_staticData.GetInventory(ItemType.RIFLE_AMMO);
            gunData = (AmmoConfig)_staticData.GetInventory(ItemType.GUN_AMMO);
        }

        private void OnInventoryStateChanged(object sender)
        {
            foreach (var slot in _uiSlots)
            {
                slot.Refresh();
            }
        }
    }
}