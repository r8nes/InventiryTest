using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public interface IFacade : IService
    {
        void GetAmmoDatas();
        void GetEquipmentDatas();
    }
}
