using UnityEngine;

namespace InventoryTest.Service
{
    public interface IAssetsProvider : IService
    {
        /// <summary>
        ///  Instantiate object without position.
        /// </summary>
        /// <param name="path">Asset path direction</param>
        /// <returns>New object</returns>
        GameObject Instantiate(string path);
    }
}
