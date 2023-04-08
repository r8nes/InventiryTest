using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "EquipmentItemInfo", menuName = "SO/EquipmentInfo")]
    public class EquimpentConfig : InventoryItemInfo
    {
        [SerializeField] private int _equipmentValue;
    }
}