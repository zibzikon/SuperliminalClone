using Code.Domain.Factories;
using Code.Domain.Infrastructure;
using Code.Domain.Infrastructure.Interfaces;
using Code.Domain.Visualisation;
using Code.Interfaces;
using Zenject;

namespace Code.Domain.Regestration.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<IAssetsProvider>().To<ResourcesBasedAssetsProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();
            
            Container.Bind<ISceneLoadingVisualizer>().To<SceneLoadingVisualizer>().AsSingle();
            
            Container.Bind<IGameStateFactory>().To<GameStateFactory>().AsSingle();
            Container.Bind<ISceneTransitionWindowFactory>().To<SceneTransitionWindowFactory>().AsSingle();
            
            Container.Bind<ISceneLoadingContext>().To<SceneLoadingContext>().AsSingle();
            Container.Bind<ILevelSceneLoadingContext>().To<LevelSceneLoadingContext>().AsSingle();
        }
    }
}