using Code.Game;
using Code.GamePlay;
using Code.GamePlay.Contexts;
using UnityEngine;
using Zenject;

namespace Code.Registration.Installers.Scene
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelContext _levelContext;
        [SerializeField] private LevelController levelController;
            
        public override void InstallBindings()
        {
            Container.BindInstance(_levelContext);
            Container.BindInstance(levelController);
        }
    }
}