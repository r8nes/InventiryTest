using InventoryTest.Logic.Abstract;
using InventoryTest.Service;
using UnityEngine;

public class UIInventory : MonoBehaviour 
{
    // TODO Вынести данные из вьюхи
    private IFacade _facade;

    private AmmoConfig _ammoConfig;
    private EquimpentConfig _equimpentConfig;
  
    public InventoryWithSlots Inventory => test.Inventory;

    private Test test;

    public void Construct(AmmoConfig ammoConfig, EquimpentConfig equimpentConfig, IFacade facade) 
    {
        _ammoConfig = ammoConfig;
        _equimpentConfig = equimpentConfig;
        _facade = facade;
    }

    public void Awake()
    {
        UIInventorySlot[] uiSlots = GetComponentsInChildren<UIInventorySlot>();

        test = new Test(_ammoConfig, _equimpentConfig, uiSlots, _facade);
        test.UpdateInventory();
    }

    public void AddRandomBullets() 
    {
         
    }
}
