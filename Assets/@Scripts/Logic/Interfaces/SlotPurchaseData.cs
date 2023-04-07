using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "SlotPurchaseInfo", menuName = "SO/Slot Purchase Config")]

    public class SlotPurchaseData : ScriptableObject, IBuyable
    {
        [SerializeField] private int _price;
        [SerializeField] private bool _needToBuy;

        public int Price => _price;
        public bool NeedToBuy => _needToBuy;
    }
}