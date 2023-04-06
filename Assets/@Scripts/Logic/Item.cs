using System;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class Item : MonoBehaviour, IInventoryItem
    {
        public int Amount { get ; set; }
        public int MaxItemInSlot { get; set; }
        public bool IsEquipped { get; set; }

        public Type Type => throw new NotImplementedException();

        public IInventoryItem Clone()
        {
            throw new NotImplementedException();
        }
    }
}
