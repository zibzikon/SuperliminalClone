using System;
using Code.Game.SystemsRegistration;
using UnityEngine;
using Zenject;

namespace Code.Game
{
    public class LevelController : MonoBehaviour
    {
        private GamePlayFeature _gamePlayFeature;
        private Entitas.Systems _systems;
        
        [Inject]
        public void Construct(GamePlayFeature gamePlayFeature)
        {
            _gamePlayFeature = gamePlayFeature;
        }

        private void Awake()
        {
            _systems.Add(_gamePlayFeature);
            
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
        }

        private void OnDestroy()
        {
            _systems.Cleanup();
        }
    }
}