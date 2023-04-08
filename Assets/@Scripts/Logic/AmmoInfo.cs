using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "AmmoItemInfo", menuName = "SO/AmmoInfo")]
    public class AmmoInfo : InventoryItemInfo
    {
        [SerializeField] private int _damageValue;
    }
}