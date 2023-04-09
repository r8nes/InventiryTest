using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public interface IFacade : IService
    {
        void Warm();
        public T GetAmmo<T>() where T : IAmmo;
    };
}
