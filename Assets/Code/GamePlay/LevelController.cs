using System;
using Code.Game.SystemsRegistration;
using UnityEngine;
using Zenject;

namespace Code.Game
{
    public class LevelController : MonoBehaviour
    {
        private readonly Entitas.Systems _systems = new ();
        
        [Inject]
        public void Construct(FullGameFeature gameFeature)
        {
            _systems.Add(gameFeature);
        }

        private void Start()
        {
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDestroy()
        {
            _systems.Cleanup();
        }
    }
}