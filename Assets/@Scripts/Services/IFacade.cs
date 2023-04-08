using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public interface IFacade : IService
    {
        List<Ammo> GetAmmoDatas();
        List<Ammo> GetEquipmentDatas();
    }
}
