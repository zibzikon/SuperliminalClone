using Code.Data.ResourcesData;
using Code.Infrastructure.Interfaces;
using Code.Services.Interfaces;
using Code.StateMachine.Interfaces;
using Code.Visualisation.Interfaces;

namespace Code.StateMachine.GameStates
{
    public class LoadGameState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ISceneLoadingVisualizer _sceneLoadingVisualizer;
        private readonly GameResourcesData _gameResourcesData;

        public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            ISceneLoadingVisualizer sceneLoadingVisualizer, GameResourcesData gameResourcesData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _sceneLoadingVisualizer = sceneLoadingVisualizer;
            _gameResourcesData = gameResourcesData;
        }
        
        public async void Enter()
        {
            var sceneLoadingTask = _sceneLoader.LoadSceneAsync(_gameResourcesData.MainMenuSceneName);
            _sceneLoadingVisualizer.StartVisualising(_sceneLoader.SceneLoadingAsyncOperation);
            
            await sceneLoadingTask;
        }

        public void Exit()
        {
            
        }
    }
}