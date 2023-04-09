using InventoryTest.Logic.Abstract;
using InventoryTest.Service;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    private IFacade _facade;
    private IStaticDataService _staticData;
  
    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            test.AddItem(TypeFlag.AMMO,3);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            test.AttackBullet();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            test.AddItem(TypeFlag.EQUIPMENT, 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            test.DeleteRandom();
        }
    }

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
}
