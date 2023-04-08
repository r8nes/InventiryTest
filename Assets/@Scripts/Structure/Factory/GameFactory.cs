using InventoryTest.Assets;
using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assets;

        public GameFactory(IAssetsProvider assets)
        {
            _assets = assets;
        }

        #region CreateMethods

        public GameObject CreateHud()
        {
            GameObject hud = Initial(AssetsPath.GLOBAL_HUD_PATH);
            return hud;
        }

        #endregion

        private GameObject Initial(string prefabPath) => _assets.Instantiate(path: prefabPath);
    }
}