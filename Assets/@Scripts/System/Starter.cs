using InventoryTest.Service;
using InventoryTest.State;

namespace InventoryTest.System
{
    public class Starter
    {
        public GameStateMachine StateMachine;

        public Starter()
        {
            StateMachine = new GameStateMachine(AllServices.Container);
        }
    }
}
