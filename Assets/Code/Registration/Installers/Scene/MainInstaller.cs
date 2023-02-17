using Code.Mediators;
using Code.UI.Windows;
using UnityEngine;
using Zenject;
using SceneContext = Code.GamePlay.Contexts.SceneContext;

namespace Code.Registration.Installers.Scene
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private SceneContext mainContext;
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private MainMediator _mediator;
        public override void InstallBindings()
        {
            Container.BindInstance(mainContext);
            Container.BindInstance(_mainMenuWindow).AsSingle();
            Container.BindInstance(_mediator).AsSingle();
        }
    }
}