namespace InventoryTest.Logic.Abstract
{
    public class HelmItem : ItemBase, IEquipment
    {
        public int Defence { get; set; }

        public override void Construct(IInventoryItemInfo info) => base.Construct(info);
        
        public override IInventoryItem Clone()
        {
            HelmItem cloneItem = new HelmItem();

            cloneItem.Construct(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }
}