using InventoryTest.Logic.Abstract;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    [SerializeField] private InventoryItemInfo _info1;
    [SerializeField] private InventoryItemInfo _info2;

    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    private void Awake()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();

        test = new Test(_info1, _info2, uiSlots);
        test.FillSlots();
    }
}