namespace RopeMaster.State
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() => _gameStateMachine.Enter<GameLoopState>();

        public void Exit() { }
    }
}   