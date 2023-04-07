using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventoryTest.Logic.Abstract
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private Image _slotImage;
        [SerializeField] private TextMeshProUGUI _slotText;
        [SerializeField] private UIInventoryItem _uIInventoryItem;
        [SerializeField] private SlotPurchaseData _slotPurchaseData;

        private UIInventory _uInventory;
        public IInventorySlot Slot { get; private set; }

        private void Awake() => _uInventory = GetComponentInParent<UIInventory>();

        public void SetSlot(IInventorySlot newSlot)
        {
            Slot = newSlot;
            SetBuyable();
        }

        public void SetBuyable() 
        {
            if (_slotPurchaseData != null)
                Slot.SetPurchaseData(_slotPurchaseData);
        }

        public override void OnDrop(PointerEventData eventData)
        {
            UIInventoryItem otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
            UIInventorySlot otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
            IInventorySlot otherSlot = otherSlotUI.Slot;

            InventoryWithSlots inventory = _uInventory.Inventory;

            inventory.TransferItemsToSlot(this, otherSlot, Slot);

            Refresh();
            otherSlotUI.Refresh();
        }

        public void Refresh()
        {
            if (Slot != null)
            {
                _uIInventoryItem.Refresh(Slot);

                _slotText.gameObject.SetActive(Slot.NeedToBuy);
                ChangeSpriteAlpha(1);

                if (Slot.NeedToBuy)
                    ChangeSpriteAlpha(0.5f);
            }
        }

        private void ChangeSpriteAlpha(float alphaValue)
        {
            Color alpha = _slotImage.color;
            alpha.a = alphaValue;
            _slotImage.color = alpha;
        }
    }
}