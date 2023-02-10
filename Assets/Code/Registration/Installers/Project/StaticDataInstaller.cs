using System.Collections.Generic;
using Code.Data.ResourcesData;
using UnityEngine;
using Zenject;

namespace Code.Registration.Installers.Project
{
    public class StaticDataInstaller : MonoInstaller
    {
        [SerializeField] private GameResourcesData _gameResourcesData;
        [SerializeField] private UIResourcesData _uiResourcesData;
        
        [SerializeField] private List<SceneTransitionResourceData> _sceneTransitions;
        [SerializeField] private List<LevelPreviewResourceData> _levelsPreviews;
        [SerializeField] private List<LevelResourceData> _levels;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameResourcesData).AsSingle();
            Container.BindInstance(_uiResourcesData).AsSingle();
            
            Container.Bind<IEnumerable<SceneTransitionResourceData>>().FromInstance(_sceneTransitions).AsSingle();
            Container.Bind<IEnumerable<LevelPreviewResourceData>>().FromInstance(_levelsPreviews).AsSingle();
            Container.Bind<IEnumerable<LevelResourceData>>().FromInstance(_levels).AsSingle();
        }
        
    }
}