namespace InventoryTest.Logic.Abstract
{
    public class GunItem : ItemBase, IEquipment
    {
        public int Defence { get; set; }
        public override void Construct(IInventoryItemInfo info) => base.Construct(info);
        
        public override IInventoryItem Clone()
        {
            GunItem cloneItem = new GunItem();

            cloneItem.Construct(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }
}