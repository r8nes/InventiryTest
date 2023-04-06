using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryTest.Logic.Abstract
{
    public class InventoryWithSlots : IInventory
    {
        public int Capacity { get; set; }
        public bool IsFull => _slots.All(slot => slot.IsFull);

        private List<IInventorySlot> _slots;

        public event Action<object, IInventoryItem, int> OnInventoryAddedIvent;

        public InventoryWithSlots(int capacity)
        {
            Capacity = capacity;

            _slots = new List<IInventorySlot>(capacity);

            for (int i = 0; i < capacity; i++)
                _slots.Add(new InventorySlot());
        }

        public bool TryToAdd(object sender, IInventoryItem item)
        {
            IInventorySlot sameNoEmptySlot = _slots.
                Find(slot => !slot.IsEmpty
            && slot.ItemType == item.Type
            && !slot.IsFull);

            if (sameNoEmptySlot != null)
                return TryToAddToSlot(sender, sameNoEmptySlot, item);

            IInventorySlot emptySlot = _slots.Find(slot => slot.IsEmpty);

            if (emptySlot != null)
                return TryToAddToSlot(sender, emptySlot, item);

            return false;
        }

        private bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            bool isFits = slot.Amount + item.Amount <= item.MaxItemInSlot;
            int amountToAdd = isFits
                ? item.Amount
                : item.MaxItemInSlot - slot.Amount;
            int amountLeft = item.Amount - amountToAdd;
            
            IInventoryItem clonedItem = item.Clone();
            clonedItem.Amount = amountToAdd;

            if (slot.IsEmpty)
                slot.SetItem(clonedItem);
            else
                slot.Item.Amount += amountToAdd;

            OnInventoryAddedIvent?.Invoke(sender, item, amountToAdd);

            if (amountLeft <= 0) return true;

            item.Amount = amountLeft;

            return TryToAdd(sender, item);
        }

        public void Remove(object sender, Type itemType, int amount = 1)
        {
            IInventorySlot[] slotsWithItem =  GetAllSlots(itemType);

            if (slotsWithItem.Length == 0) return;

            int amountToRemove = amount;
            int count = slotsWithItem.Length;

            for (int i = count - 1; i >= 0; i--)
            {
                IInventorySlot slot = slotsWithItem[i];

                if (slot.Amount >= amountToRemove) 
                {
                    slot.Item.Amount -= amountToRemove;
                    
                    if (slot.Amount <= 0)
                        slot.Clear();

                    break;
                }

                amountToRemove -= slot.Amount;
                slot.Clear();
            }
        }

        public IInventorySlot[] GetAllSlots(Type itemType)
        {
            return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            throw new NotImplementedException();
        }

        #region Getters

        public int GetItemAmount(Type itemType)
        {
            int amount = 0;

            List<IInventorySlot> allItemSlots = _slots.
                FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);

            foreach (IInventorySlot itemSlot in allItemSlots)
                amount += itemSlot.Amount;

            return amount;
        }

        public IInventoryItem[] GetAllItems()
        {
            List<IInventoryItem> allItem = new List<IInventoryItem>();

            foreach (IInventorySlot slot in _slots)
            {
                if (!slot.IsEmpty)
                    allItem.Add(slot.Item);
            }

            return allItem.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            List<IInventoryItem> allItemOfType = new List<IInventoryItem>();
            List<IInventorySlot> slotsOfType =
                _slots.
                FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);

            foreach (IInventorySlot slot in slotsOfType)
                allItemOfType.Add(slot.Item);

            return allItemOfType.ToArray();
        }

        public IInventoryItem[] GetEquippedItems()
        {
            List<IInventorySlot> requiredSlots = _slots.
                FindAll(slot => !slot.IsEmpty && slot.Item.IsEquipped);
            List<IInventoryItem> equippedItems = new List<IInventoryItem>();

            foreach (var slot in requiredSlots)
                equippedItems.Add(slot.Item);

            return equippedItems.ToArray();
        }

        public IInventoryItem GetItem(Type itemType) =>
            _slots.Find(slot => slot.ItemType == itemType).Item;

        #endregion
    }
}
