using System;
using UnityEngine;
using Zenject;

namespace Code.Domain
{
    public class Bootstrap : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Initialize(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.SwitchState<LoadGameState>();
        }
    }
}