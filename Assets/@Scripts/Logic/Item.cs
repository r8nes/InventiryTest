using System;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Item : MonoBehaviour, IInventoryItem
    {
        public int Amount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxItemInSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEquipped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type Type => throw new NotImplementedException();

        public IInventoryItem Clone()
        {
            throw new NotImplementedException();
        }
    }
}
