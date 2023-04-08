using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "AmmoItemInfo", menuName = "SO/AmmoInfo")]
    public class AmmoConfig : InventoryItemInfo
    {
        [SerializeField] private int _damageValue;

        public int DamageValue => _damageValue;
    }
}