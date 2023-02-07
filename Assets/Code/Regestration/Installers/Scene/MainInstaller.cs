using Code.Domain.Mediators;
using UnityEngine;
using Zenject;

namespace Code.Domain.Regestration.Installers.Scene.MainMenuScene
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MainMediator _mainMediator;
        [SerializeField] private SceneManagement.Scene _mainContext;
        
        public override void InstallBindings()
        {
            Container.Bind<MainMediator>().FromInstance(_mainMediator).AsSingle();
            Container.BindInstance(_mainContext);
        }
    }
}