using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "SO/ItemInfo")]
    public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _descirption;
        [SerializeField] private int _maxItemInShot;
        [SerializeField] private Sprite _spriteIcon;

        public string Id => _id;
        public string Title => _title;
        public string Description => _descirption;
        public int MaxItemInSlot => _maxItemInShot;
        public Sprite SpriteIcon => _spriteIcon;
    }
}