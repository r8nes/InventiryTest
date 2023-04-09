using System.Collections.Generic;
using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Test
    {
        // TODO вынести в SO
        private const int SLOT_CAPACITY = 30;

        private readonly IFacade _facade;
        private readonly IStaticDataService _staticData;

        private readonly UIInventorySlot[] _uiSlots;

        private readonly List<IInventoryItem> Ammos = new List<IInventoryItem>(5);
        private readonly List<IInventoryItem> Equipments = new List<IInventoryItem>(5);

        public InventoryWithSlots Inventory { get; }

        public Test(UIInventorySlot[] slots, IFacade facade, IStaticDataService staticData)
        {
            _staticData = staticData;
            _uiSlots = slots;

            _facade = facade;
            _facade.Warm();

            Inventory = new InventoryWithSlots(SLOT_CAPACITY);

            Inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
            Inventory.OnInventoryStateChangedEvent += SetupUI;

            SetupInventoryData();
            SetupUI(this);
        }

        public void AddItem(TypeFlag flag, int amount)
        {
            IInventorySlot[] inventorySlots = Inventory.GetAllSlots();
            List<IInventorySlot> availableSlots = new List<IInventorySlot>(inventorySlots);

            switch (flag)
            {
                case TypeFlag.AMMO:
             
                    for (int i = 0; i < Ammos.Count; i++)
                    {
                        var filledSlot = AddItem(availableSlots, Ammos[i], amount);
                        availableSlots.Remove(filledSlot);
                    }

                    break;

                case TypeFlag.EQUIPMENT:
                    
                    for (int i = 0; i < Equipments.Count; i++)
                    {
                        var filledSlot = AddItem(availableSlots, Equipments[i], amount);
                        availableSlots.Remove(filledSlot);
                    }

                    break;
            }
        }

        public void AttackBullet()
        {
            int rand = Random.Range(0, Ammos.Count);
            Inventory.Remove(this, Ammos[rand].Type);
        }

        public void DeleteRandom() 
        {
            var slots = Inventory.GetAllItems();
            var randItemIndex = Random.Range(0, slots.Length);
            var randItem = slots[randItemIndex];

            Inventory.Remove(this, randItem.Type, randItem.State.Amount);
        }

        private IInventorySlot AddItem(List<IInventorySlot> slots, IInventoryItem item, int amount)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                item.State.Amount = amount;
                Inventory.TryToAddToSlot(this, slots[i], item);
                return slots[i];
            }

            return null;
        }

        private void SetupInventoryData()
        {
            InitEquipmentData();
            InitAmmoData();
        }

        private void SetupUI(object sender)
        {
            var allSlots = Inventory.GetAllSlots();
            var allSlotsCount = allSlots.Length;

            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];

                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        private void OnInventoryStateChanged(object sender)
        {
            foreach (var slot in _uiSlots)
            {
                slot.Refresh();
            }
        }

        //TODO

        #region Initials

        private void InitAmmo(out RiffleAmmo riffleAmmo, out GunAmmo gunAmmo)
        {
            riffleAmmo = _facade.GetAmmo<RiffleAmmo>();
            gunAmmo = _facade.GetAmmo<GunAmmo>();
        }

        private void InitAmmoConfig(out AmmoConfig riffleAmmoConfig, out AmmoConfig gunAmmoConfig)
        {
            riffleAmmoConfig = (AmmoConfig)_staticData.GetInventory(ItemType.RIFLE_AMMO);
            gunAmmoConfig = (AmmoConfig)_staticData.GetInventory(ItemType.GUN_AMMO);
        }
        
        private void InitAmmoData()
        {
            InitAmmo(out RiffleAmmo riffleAmmo, out GunAmmo gunAmmo);
            InitAmmoConfig(out AmmoConfig riffleData, out AmmoConfig gunData);

            riffleAmmo.Construct(riffleData);
            gunAmmo.Construct(gunData);

            Ammos.Add(riffleAmmo);
            Ammos.Add(gunAmmo);
        }

        private void InitEquipment(out HelmItem helmItem, out GunItem gunItem, out ArmorItem armorItem)
        {
            helmItem = _facade.GetEquipment<HelmItem>();
            gunItem = _facade.GetEquipment<GunItem>();
            armorItem = _facade.GetEquipment<ArmorItem>();
        }

        private void InitEquipmentConfig(out EquimpentConfig helmConfig, out EquimpentConfig gunConfig, out EquimpentConfig armorConfig)
        {
            helmConfig = (EquimpentConfig)_staticData.GetInventory(ItemType.HELM_EQUIPMENT);
            gunConfig = (EquimpentConfig)_staticData.GetInventory(ItemType.GUN_EQUIPMENT);
            armorConfig = (EquimpentConfig)_staticData.GetInventory(ItemType.ARMOR_EQUIPMENT);
        }
        
        private void InitEquipmentData()
        {
            InitEquipment(out HelmItem helmItem, out GunItem gunItem, out ArmorItem armorItem);
            InitEquipmentConfig(out EquimpentConfig helmConfig, out EquimpentConfig gunConfig, out EquimpentConfig armorConfig);

            helmItem.Construct(helmConfig);
            gunItem.Construct(gunConfig);
            armorItem.Construct(armorConfig);

            Equipments.Add(helmItem);
            Equipments.Add(gunItem);
            Equipments.Add(armorItem);
        }

        #endregion
    }
}