using Code.Domain.Mediators;
using UnityEngine;
using Zenject;

namespace Code.Domain.Regestration.Installers.Scene.MainMenuScene
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private SceneManagement.Scene _mainContext;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_mainContext);
        }
    }
}