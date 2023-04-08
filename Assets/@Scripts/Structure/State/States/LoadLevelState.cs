using InventoryTest.Factory;
using InventoryTest.Logic;
using InventoryTest.Logic.Abstract;
using InventoryTest.Service;
using UnityEngine;

namespace InventoryTest.State
{
    public class LoadLevelState : IState
    {
        private readonly IFacade _facade;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IStaticDataService staticData, IFacade facade)
        {
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _staticData = staticData;
            _facade = facade;
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
           GameObject hud = InitHud();

            UIInventory inventory = hud.GetComponent<UIInventory>();
            
            AmmoConfig ammoConfig = (AmmoConfig)_staticData.GetInventory(ItemType.AMMO);
            EquimpentConfig equimpentConfig = (EquimpentConfig)_staticData.GetInventory(ItemType.EQUIPMENT);

            inventory.Construct(ammoConfig, equimpentConfig, _facade);

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