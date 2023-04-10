using InventoryTest.Service;

namespace InventoryTest.State
{
    public class LoadProgressState : IState
    {
        private readonly IStorageService _storageService;
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine, IStorageService storageService)
        {
            _storageService = storageService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }
    }
}