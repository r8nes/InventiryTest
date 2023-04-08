using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "EquipmentItemInfo", menuName = "SO/EquipmentInfo")]
    public class EquimpentInfo : InventoryItemInfo
    {
        [SerializeField] private int _equipmentValue;
    }
}