using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "SlotPurchaseInfo", menuName = "SO/Slot Purchase Config")]

    public class SlotPurchaseData : ScriptableObject, IPurchasable
    {
        [SerializeField] private int _price;
        [SerializeField] private bool _needToBuy;

        public int Price { get => _price; set => _price = value; }
        public bool NeedToBuy { get => _needToBuy; set => _needToBuy = value; }
    }
}