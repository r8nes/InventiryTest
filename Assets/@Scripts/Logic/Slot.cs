using System;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Slot : MonoBehaviour, IInventorySlot
    {
        public int Amount => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public bool IsFull => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public Type ItemType => throw new NotImplementedException();

        public IInventoryItem Item => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SetItem(IInventoryItem item)
        {
            throw new NotImplementedException();
        }
    }
}