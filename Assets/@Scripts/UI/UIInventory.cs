using InventoryTest.Logic.Abstract;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    [SerializeField] private InventoryItemInfo _info1;

    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    private void Awake()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();

        test = new Test(_info1, uiSlots);
        test.FillSlots();
    }
}