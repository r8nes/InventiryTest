using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public class ItemFacade : IFacade
    {
        private ItemContainer _itemContainer;

        public ItemFacade(ItemContainer itemContainer)
        {
            _itemContainer = itemContainer;
            _itemContainer.AddItemsVariaty();
        }

        public void Init() 
        {
            _itemContainer.AddAmmoVariaty(new GunAmmo);
        }

        public void GetAmmoDatas()
        {
        }

        public void GetEquipmentDatas()
        {
        }
    }
}
