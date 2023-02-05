using Code.Domain.Mediators;
using UnityEngine;
using Zenject;

namespace Code.Domain.Regestration.Installers.Scene.BootScene
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private Bootstrap _bootstrap;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_bootstrap);
        }
        
    }
}