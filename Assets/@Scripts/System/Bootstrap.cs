using InventoryTest.State;
using UnityEngine;

namespace InventoryTest.System
{
    public class Bootstrap : MonoBehaviour
    {
        
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
