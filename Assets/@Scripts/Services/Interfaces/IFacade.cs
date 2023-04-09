using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public interface IFacade : IService
    {
        void Warm();
        public T GetEquipment<T>() where T : IEquipment;
        public T GetAmmo<T>() where T : IAmmo;
    };
}
