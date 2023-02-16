using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Data.ResourcesData.Enums;
using Code.Factories;
using Code.Factories.Interfaces;
using Code.Factories.Interfaces.UI;
using Code.Factories.UI;
using Code.Game.Interfaces;
using Code.Infrastructure;
using Code.Infrastructure.Interfaces;
using Code.Services;
using Code.Services.Interfaces;
using Code.StateMachine;
using Code.StateMachine.Interfaces;
using Code.Visualisation;
using Code.Visualisation.Interfaces;
using Zenject;

namespace Code.Registration.Installers.Project
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGame>().To<Game.Game>().AsSingle()
                .WithArguments(new List<LevelData>{new (0, LevelState.Unlocked)}.AsEnumerable());
            
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<IAssetsProvider>().To<ResourcesBasedAssetsProvider>().AsSingle();
            Container.Bind<ILevelSelectableUIControlSelector>().To<LevelSelectableUIControlSelector>().AsSingle();
            Container.Bind<IViewService>().To<UnityViewService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoaderWithLoadingVisualization>().AsSingle();
            Container.Bind<IIdentifierGenerator>().To<IdentifierGenerator>().AsSingle();
            
            Container.Bind<ISceneLoadingVisualizer>().To<SceneLoadingVisualizer>().AsSingle();
            
            Container.Bind<IGameStateFactory>().To<GameStateFactory>().AsSingle();
            Container.Bind<ILevelPreviewFactory>().To<LevelPreviewFactory>().AsSingle();
            Container.Bind<ILevelSelectableUIControlFactory>().To<LevelSelectableUIControlFactory>().AsSingle();
            Container.Bind<ISceneTransitionWindowFactory>().To<SceneTransitionWindowFactory>().AsSingle();
            
            Container.Bind<ISceneLoadingContext>().To<SceneLoadingContext>().AsSingle();
            Container.Bind<ILevelSceneLoadingContext>().To<LevelSceneLoadingContext>().AsSingle();
        }
    }
}