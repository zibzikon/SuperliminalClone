using Code.Domain.Infrastructure;
using Code.Domain.Infrastructure.Interfaces;
using Code.Interfaces;
using Zenject;

namespace Code.Domain.Regestration.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<ILevelSceneContextContainer>().To<LevelSceneContextContainer>().AsSingle();
            Container.Bind<IAssetsProvider>().To<ResourcesBasedAssetsProvider>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneManagerBasedSceneLoader>().AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<IGameStateFactory>().To<GameStateFactory>().AsSingle();
        }
    }
}