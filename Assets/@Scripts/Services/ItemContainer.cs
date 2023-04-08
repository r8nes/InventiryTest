using System.Collections.Generic;
using System.Linq;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    // TODO
    public class ItemContainer
    {
        private List<ItemBase> _items = new List<ItemBase>(30);

        public void AddItemsVariaty(ItemBase derivedClass) => _items.Add(derivedClass);
        public void AddItemsVariaty(ItemBase[] derivedClass)
        {
            for (int i = 0; i < derivedClass.Length; i++)
                _ammos.Add(derivedClass[i]);
        }

        public T GetAmmoVariaty<T>() where T : class, IAmmo => _items.OfType<T>().FirstOrDefault();
        public T GetEqipmentVariaty<T>() where T : class, IEquipment => _items.OfType<T>().FirstOrDefault();
    }
}
