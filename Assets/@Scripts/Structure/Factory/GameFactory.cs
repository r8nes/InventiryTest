using InventoryTest.Assets;
using InventoryTest.Logic;
using InventoryTest.Logic.Abstract;
using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assets;
        private readonly IStaticDataService _staticData;

        public GameFactory(IAssetsProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        #region CreateMethods

        public GameObject CreateHud()
        {
            GameObject hud = Initial(AssetsPath.GLOBAL_HUD_PATH);

            var inventory = hud.GetComponent<UIInventory>();

            inventory.Ammo = (AmmoInfo)_staticData.GetInventory(ItemType.AMMO);
            inventory.Equimpent = (EquimpentInfo)_staticData.GetInventory(ItemType.EQUIPMENT);

            return hud;
        }

        #endregion

        private GameObject Initial(string prefabPath) => _assets.Instantiate(path: prefabPath);
    }
}