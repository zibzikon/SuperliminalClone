using Code.Mediators;
using Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace Code.Registration.Installers.Scene
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private SceneManagement.Scene _mainContext;
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private MainMediator _mediator;
        public override void InstallBindings()
        {
            Container.BindInstance(_mainContext);
            Container.BindInstance(_mainMenuWindow).AsSingle();
            Container.BindInstance(_mediator).AsSingle();
        }
    }
}