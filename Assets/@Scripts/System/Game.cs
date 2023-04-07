using RopeMaster.Service;
using RopeMaster.State;

namespace RopeMaster.System
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
