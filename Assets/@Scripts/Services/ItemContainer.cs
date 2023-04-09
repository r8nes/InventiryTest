using System;
using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public class ItemContainer : IFacade
    {
        private Dictionary<Type, IAmmo> _ammoObjects = new Dictionary<Type, IAmmo>();

        public void Warm() 
        {
           AddAmmo(new RiffleAmmo());
           AddAmmo(new GunAmmo());
        }

        public void AddAmmo<T>(T ammo) where T : IAmmo
        {
            var type = typeof(T);
            if (!_ammoObjects.ContainsKey(type))
            {
                _ammoObjects.Add(type, ammo);
            }
        }

        public T GetAmmo<T>() where T : IAmmo
        {
            var type = typeof(T);
            if (_ammoObjects.ContainsKey(type))
            {
                return (T)_ammoObjects[type];
            }
            else
            {
                return default(T);
            }
        }
    }
}
