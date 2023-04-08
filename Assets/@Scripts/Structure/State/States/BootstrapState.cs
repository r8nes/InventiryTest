using InventoryTest.Assets;
using InventoryTest.Factory;
using InventoryTest.Service;
using InventoryTest.System;

namespace InventoryTest.State
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

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState>();

        private void GloabalRegisterService()
        {
            RegisterStateMachine();
            RegisterAssetProvider();
            RegisterStaticData();
            RegisterGameFactory();
        }

        #region Register

        private void RegisterStateMachine() 
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
        }

        private void RegisterAssetProvider()
        {
            var assetProvider = new AssetsProvider();
            _services.RegisterSingle<IAssetsProvider>(assetProvider);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }


        private void RegisterGameFactory()
        {
            _services.RegisterSingle<IGameFactory>(
                            new GameFactory(
                            _services.Single<IAssetsProvider>(),
                            _services.Single<IStaticDataService>()));
        }

        #endregion
    }
}