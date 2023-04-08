using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public interface IFacade : IService
    {
        public IAmmo GetAmmoData();
        public IEquipment GetEquipmentData();
    }
}
