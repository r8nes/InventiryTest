using System;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventory
    {
        int Capacity { get; set; }
        bool IsFull { get; }

        int GetItemAmount(Type itemType);
        IInventoryItem GetItem(Type itemType);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(Type itemType);
        IInventoryItem[] GetEquippedItems();

        bool CheckSlot(IInventorySlot slot);
        bool HasItem(Type type, out IInventoryItem item);
        void Remove(object sender, Type itemType, int amount = 1);
        bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item);
    }
}
