using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot 
{
    public UIInventorySlot Slot { get; private set; }

    public void SetSlot(UIInventorySlot newSlot) => Slot = newSlot;

    public override void OnDrop(PointerEventData eventData)
    {
        UIInventoryItem otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        UIInventorySlot otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
        UIInventorySlot otherSlot = otherSlotUI.Slot;



    }
}
