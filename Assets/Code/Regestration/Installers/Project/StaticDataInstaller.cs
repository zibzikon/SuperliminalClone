using System.Collections.Generic;
using Code.Data.Static;
using Code.Domain.Data.Static;
using UnityEngine;
using Zenject;

namespace Code.Domain.Regestration.Installers
{
    public class StaticDataInstaller : MonoInstaller
    {
        [SerializeField] private GameStaticData _gameStaticData;
        [SerializeField] private List<SceneTransitionStaticData> _sceneTransitions;
        public override void InstallBindings()
        {
            Container.BindInstance(_gameStaticData).AsSingle();
            Container.Bind<IEnumerable<SceneTransitionStaticData>>().FromInstance(_sceneTransitions).AsSingle();
        }
        
    }
}