using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "AmmoItemInfo", menuName = "SO/AmmoInfo")]
    public class AmmoConfig : InventoryItemInfo
    {
        [Header("AmmoSettings")]
        [SerializeField] private int _damageValue;

        public int DamageValue => _damageValue;
    }
}