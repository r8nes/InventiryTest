using InventoryTest.Logic.Abstract;
using InventoryTest.Service;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    private IFacade _facade;
    private IStaticDataService _staticData;
  
    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    public void Construct(IStaticDataService staticData, IFacade facade) 
    {
        _staticData = staticData;
        _facade = facade;
    }

    public void Init()
    {
        UIInventorySlot[] uiSlots = GetComponentsInChildren<UIInventorySlot>();
        test = new Test(uiSlots, _facade, _staticData);
    }

    public void Shoot() => test.Shoot();
    public void AddItem() => test.AddItem(TypeFlag.AMMO, 3);
    public void AddEqipment() => test.AddItem(TypeFlag.EQUIPMENT, 1);
    public void Remove() => test.DeleteRandom();
}
