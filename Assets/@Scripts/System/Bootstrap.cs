using InventoryTest.State;
using UnityEngine;

namespace InventoryTest.System
{
    public class Bootstrap : MonoBehaviour
    {
        private Starter _game;

        private void Awake()
        {
            _game = new Starter();
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
