namespace InventoryTest.State
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}