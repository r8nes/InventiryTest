using RopeMaster.State;
using UnityEngine;

namespace RopeMaster.System
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
