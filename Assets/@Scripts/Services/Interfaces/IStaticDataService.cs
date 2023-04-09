using System;
using InventoryTest.Logic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public interface IStaticDataService : IService
    {
        InventoryItemInfo GetInventory(ItemType TypeId);

        void Load();
    }
}