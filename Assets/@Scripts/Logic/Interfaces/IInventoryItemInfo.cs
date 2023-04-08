using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventoryItemInfo 
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemInSlot { get; }
        float Weight { get; }

        Sprite SpriteIcon { get; }
        ItemType ItemTypeID { get; }
    }
}
