using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryTest.Logic.Abstract
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private UIInventoryItem _uIInventoryItem;
        public IInventorySlot Slot { get; private set; }

        private UIInventory _uInventory;

        private void Awake() => _uInventory = GetComponentInParent<UIInventory>();

        public void SetSlot(IInventorySlot newSlot) => Slot = newSlot;

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
            }
        }
    }
}