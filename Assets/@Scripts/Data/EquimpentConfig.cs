using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "EquipmentItemInfo", menuName = "SO/EquipmentInfo")]
    public class EquimpentConfig : InventoryItemInfo
    {
        [Header("EquipmentSettings")]

        [SerializeField] private int _equipmentValue;

        public int EquipmentValue => _equipmentValue;
    }
}