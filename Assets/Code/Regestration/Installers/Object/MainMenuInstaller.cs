using System.ComponentModel;
using Code.Domain.Mediators;
using UnityEngine;
using Zenject;

namespace Code.Domain.Regestration.Installers.Object
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMediator _mainMediator;
             
         public override void InstallBindings()
         {
             Container.Bind<MainMediator>().FromInstance(_mainMediator).AsSingle();
         }
        
    }
}