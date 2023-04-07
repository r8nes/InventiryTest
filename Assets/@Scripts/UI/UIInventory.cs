using InventoryTest.Logic.Abstract;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    [SerializeField] private InventoryItemInfo _item;
    [SerializeField] private AmmoInfo _ammo;
    [SerializeField] private EquimpentInfo _equimpent;

    public InventoryWithSlots Inventory => test.Inventory;
    
    private Test test;

    private void Awake()
    {
        UIInventorySlot[] uiSlots = GetComponentsInChildren<UIInventorySlot>();

        test = new Test(_item, uiSlots);
        test.FillSlots();
    }

    public void AddRandomBullets() 
    {
         
    }
}
