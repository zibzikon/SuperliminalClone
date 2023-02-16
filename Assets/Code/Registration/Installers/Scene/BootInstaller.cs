using UnityEngine;
using Zenject;

namespace Code.Registration.Installers.Scene
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