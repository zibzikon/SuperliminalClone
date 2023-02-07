using System;
using Code.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Domain
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