using UnityEngine;

namespace InventoryTest.Logic.Abstract
{
    [CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "SO/ItemInfo")]
    public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;
        [SerializeField] private string _descirption;

        [SerializeField] private float _weight;
        [SerializeField] private int _maxItemInShot;

        [SerializeField] private Sprite _spriteIcon;
        [SerializeField] private ItemType _itemTypeId;

        public int Id => _id;
        public string Title => _title;
        public string Description => _descirption;
        public int MaxItemInSlot => _maxItemInShot;
        public float Weight => _weight;
        public Sprite SpriteIcon => _spriteIcon;
        public ItemType ItemTypeID => _itemTypeId;
    }
}