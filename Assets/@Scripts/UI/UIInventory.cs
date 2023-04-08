using InventoryTest.Logic.Abstract;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    private AmmoInfo _ammo;
    private EquimpentInfo _equimpent;

    public EquimpentInfo Equimpent { get => _equimpent; set => _equimpent = value; }
    public AmmoInfo Ammo { get => _ammo; set => _ammo = value; }

    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    private void Awake()
    {
        UIInventorySlot[] uiSlots = GetComponentsInChildren<UIInventorySlot>();

        test = new Test(_ammo, uiSlots);
        test.FillSlots();
    }

    public void AddRandomBullets() 
    {
         
    }
}
