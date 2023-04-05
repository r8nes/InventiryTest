using System;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Inventory : MonoBehaviour, IInventory
    {
        public int Capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int IsFull => throw new NotImplementedException();

        public bool Add(object sender, IInventoryItem item)
        {
            throw new NotImplementedException();
        }

        public IInventoryItem[] GetAllItems()
        {
            throw new NotImplementedException();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            throw new NotImplementedException();
        }

        public IInventoryItem[] GetEquippedItems()
        {
            throw new NotImplementedException();
        }

        public IInventoryItem GetItem(Type itemType)
        {
            throw new NotImplementedException();
        }

        public int GetItemAmount(Type itemType)
        {
            throw new NotImplementedException();
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            throw new NotImplementedException();
        }

        public void Remove(object sender, Type itemType, int amount = 1)
        {
            throw new NotImplementedException();
        }
    }
}
