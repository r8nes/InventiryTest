using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHud();
    }
}