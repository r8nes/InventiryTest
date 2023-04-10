using System;
using System.Collections.Generic;
using InventoryTest.Factory;
using InventoryTest.Service;

namespace InventoryTest.State
{
    public class GameStateMachine : IGameStateMachine
    {
        private IExitableState _activeState;

        private readonly Dictionary<Type, IExitableState> _states;

        public GameStateMachine(AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                this,
                services),

                [typeof(LoadProgressState)] = new LoadProgressState(
                this,
                services.Single<IStorageService>()),

                [typeof(LoadLevelState)] = new LoadLevelState(
                this,
                services.Single<IGameFactory>(),
                services.Single<IStaticDataService>(),
                services.Single<IFacade>()),

                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        #region State Methods

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState :
            class, IPayLoadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState :
            class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;

        #endregion
    }
}