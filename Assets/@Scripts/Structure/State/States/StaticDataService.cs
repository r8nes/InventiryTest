using System.Collections.Generic;
using System.Linq;
using InventoryTest.Logic;
using InventoryTest.Logic.Abstract;
using UnityEngine;

namespace InventoryTest.Service
{
    public class StaticDataService : IStaticDataService
    {
        private const string ITEMS_PATH = "Data/Items";

        private Dictionary<ItemType, InventoryItemInfo> _inventory;

        public void Load()
        {
            _inventory = Resources.LoadAll<InventoryItemInfo>(ITEMS_PATH)
                .ToDictionary(x => x.ItemTypeID, x => x);
        }

        public InventoryItemInfo GetInventory(ItemType TypeId) =>
            _inventory.TryGetValue(TypeId, out InventoryItemInfo data)
            ? data
            : null;
    }
}