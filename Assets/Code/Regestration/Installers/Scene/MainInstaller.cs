using Code.Domain.Mediators;
using UnityEngine;
using Zenject;

namespace Code.Domain.Regestration.Installers.Scene.MainMenuScene
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MainMediator _mainMediator;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_mainMediator);
        }
    }
}