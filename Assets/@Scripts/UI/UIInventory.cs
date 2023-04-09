using InventoryTest.Logic.Abstract;
using InventoryTest.Service;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    // TODO Вынести данные из вьюхи
    private IFacade _facade;
    private IStaticDataService _staticData;
  
    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            test.AddAmmoItem(3);
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

    public void AddRandomBullets() 
    {
         
    }
}
