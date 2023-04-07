using RopeMaster.Service;

namespace RopeMaster.State
{
    public class BootstrapState : IState
    {
        private readonly AllServices _services;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services)
        {
            _services = services;
            _stateMachine = gameStateMachine;

            GloabalRegisterService();
        }

        public void Enter() => EnterLoadLevel();

        public void Exit() { }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();

        private void GloabalRegisterService()
        {
            RegisterStateMachine();
        }

        #region Register

        private void RegisterStateMachine() 
            => _services.RegisterSingle<IGameStateMachine>(_stateMachine);

        #endregion
    }
}