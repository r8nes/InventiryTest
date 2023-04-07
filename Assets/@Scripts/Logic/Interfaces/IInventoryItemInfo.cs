using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventoryItemInfo 
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemInSlot { get; }
        float Weight { get; }
        Sprite SpriteIcon { get; }

    }
}
