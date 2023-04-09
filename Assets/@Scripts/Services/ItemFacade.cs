using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public class ItemFacade
    {
     //   private  ItemContainer _itemContainer;

     //   public void Construct(ItemContainer itemContainer)
     //   {
     //       _itemContainer = itemContainer;

     //       List<ItemBase> Items = WarmUpItems();
     //       _itemContainer.AddItemsVariaty(Items);
     //   }

     //   private List<ItemBase> WarmUpItems()
     //   {
     //       return new List<ItemBase>()
     //       {
     //           new RiffleAmmo(),
     //           new GunAmmo()
     //       };
     //   }

     //   public ItemBase GetAmmoData()
     //   {
     //       if (_itemContainer != null)
     //       {
     //           var currentItem = _itemContainer.GetAmmoVariaty<IAmmo>();
     //           return currentItem;
     //       }

     //       return null;
     //   }

     //   public IEquipment GetEquipmentData()
     //   {
     //       if (_itemContainer != null)
     //       {
     ////  var currentItem = _itemContainer.GetEqipmentVariaty<IEquipment>();
     //        //   return currentItem;
     //       }

     //       return null;
     //   }
    }
}
