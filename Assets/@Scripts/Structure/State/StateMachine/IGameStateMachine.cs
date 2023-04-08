using InventoryTest.Service;

namespace InventoryTest.State
{
    public interface IGameStateMachine : IService
    {
        /// <summary>
        /// Enter with state and scene name string
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <typeparam name="TPayLoad"></typeparam>
        /// <param name="payLoad"></param>
        void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>;

        /// <summary>
        /// Enter method with state
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        void Enter<TState>() where TState : class, IState;
    }
}