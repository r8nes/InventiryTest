namespace InventoryTest.Logic.Abstract
{
    public class ArmorItem : ItemBase, IEquipment
    {
        public int Defence { get; set; }

        public override void Construct(IInventoryItemInfo info) => base.Construct(info);

        public override IInventoryItem Clone()
        {
            ArmorItem cloneItem = new ArmorItem();

            cloneItem.Construct(Info);
            cloneItem.State.Amount = State.Amount;

            return cloneItem;
        }
    }
}