using Code.StateMachine.GameStates;
using Code.StateMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Bootstrap : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Initialize(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.SwitchState<LoadGameState>();
        }
    }
}