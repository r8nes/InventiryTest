using System;
using System.Collections.Generic;
using InventoryTest.Logic.Abstract;

namespace InventoryTest.Service
{
    public class ItemContainer : IFacade
    {
        private Dictionary<Type, IAmmo> _ammoDictionary = new Dictionary<Type, IAmmo>(10);
        private Dictionary<Type, IEquipment> _equipmentDictionary = new Dictionary<Type, IEquipment>(10);
        
        public void Warm()
        {
            AddAmmo(new RiffleAmmo());
            AddAmmo(new GunAmmo());

            AddEquipment(new HelmItem());
            AddEquipment(new GunItem());
            AddEquipment(new ArmorItem());
        }
        public T GetAmmo<T>() where T : IAmmo
        {
            var type = typeof(T);
            if (_ammoDictionary.ContainsKey(type))
            {
                return (T)_ammoDictionary[type];
            }
            else
            {
                return default(T);
            }
        }
        public T GetEquipment<T>() where T : IEquipment
        {
            var type = typeof(T);
            if (_equipmentDictionary.ContainsKey(type))
            {
                return (T)_equipmentDictionary[type];
            }
            else
            {
                return default(T);
            }
        }
        private void AddAmmo<T>(T ammo) where T : IAmmo
        {
            var type = typeof(T);
            if (!_ammoDictionary.ContainsKey(type))
            {
                _ammoDictionary.Add(type, ammo);
            }
        }
        private void AddEquipment<T>(T ammo) where T : IEquipment
        {
            var type = typeof(T);
            if (!_equipmentDictionary.ContainsKey(type))
            {
                _equipmentDictionary.Add(type, ammo);
            }
        }
    }
}
