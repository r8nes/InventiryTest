using InventoryTest.Factory;
using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.State
{
    public class LoadLevelState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IStaticDataService staticData)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _staticData = staticData;
        }

        public void Enter()
        {
            OnLoaded();
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitHud();
            _gameStateMachine.Enter<GameLoopState>();
        }


        #region Initials

        private GameObject InitHud()
        {
            GameObject hud = _gameFactory.CreateHud();

            return hud;
        }

        #endregion
    }
}