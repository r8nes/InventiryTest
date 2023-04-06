using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public class InventoryWithSlots : IInventory
    {
        public int Capacity { get; set; }
        public bool IsFull => _slots.All(slot => slot.IsFull);

        private List<IInventorySlot> _slots;

        public event Action<object, IInventoryItem, int> OnInventoryAddedEvent;
        public event Action<object, Type, int> OnInventoryRemovedEvent;

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
            bool isFits = slot.Amount + item.State.Amount <= item.Info.MaxItemInSlot;
            int amountToAdd = isFits
                ? item.State.Amount
                : item.Info.MaxItemInSlot - slot.Amount;
            int amountLeft = item.State.Amount - amountToAdd;
            
            IInventoryItem clonedItem = item.Clone();
            clonedItem.State.Amount = amountToAdd;

            if (slot.IsEmpty)
                slot.SetItem(clonedItem);
            else
                slot.Item.State.Amount += amountToAdd;

            Debug.Log($"Добавлено {item.Type}, {item.State.Amount}") ;
            OnInventoryAddedEvent?.Invoke(sender, item, amountToAdd);

            if (amountLeft <= 0) return true;

            item.State.Amount = amountLeft;

            return TryToAdd(sender, item);
        }

        public void Remove(object sender, Type item, int amount = 1)
        {
            IInventorySlot[] slotsWithItem =  GetAllSlots(item);

            if (slotsWithItem.Length == 0) return;

            int amountToRemove = amount;
            int count = slotsWithItem.Length;

            for (int i = count - 1; i >= 0; i--)
            {
                IInventorySlot slot = slotsWithItem[i];
                if (slot.Amount >= amountToRemove) 
                {
                    slot.Item.State.Amount -= amountToRemove;
                    
                    if (slot.Amount <= 0)
                        slot.Clear();

                    Debug.Log($"Убрано {item}, {amountToRemove}");
                    OnInventoryRemovedEvent?.Invoke(sender, item, amountToRemove);

                    break;
                }

                var amountToRemoved = slot.Amount;
                amountToRemove -= slot.Amount;
         
                slot.Clear();
                Debug.Log($"Убрано {item}, {amountToRemoved}");
                OnInventoryRemovedEvent?.Invoke(sender, item, amountToRemoved);
            }
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            item = GetItem(type);
            return item != null;
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

        public IInventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }

        public IInventorySlot[] GetAllSlots(Type itemType)
        {
            return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
        }

        public IInventoryItem GetItem(Type itemType) =>
            _slots.Find(slot => slot.ItemType == itemType).Item;

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
                FindAll(slot => !slot.IsEmpty && slot.Item.State.IsEquipped);
            List<IInventoryItem> equippedItems = new List<IInventoryItem>();

            foreach (var slot in requiredSlots)
                equippedItems.Add(slot.Item);

            return equippedItems.ToArray();
        }

        #endregion
    }
}
