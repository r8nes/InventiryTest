using InventoryTest.Service;
using InventoryTest.State;

namespace InventoryTest.System
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new GameStateMachine(AllServices.Container);
        }
    }
}
