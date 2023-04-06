using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    public interface IInventoryItemInfo 
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemInSlot { get; }
        Sprite SpriteIcon { get; }

        // TODO: Add Weight later
    }
}
