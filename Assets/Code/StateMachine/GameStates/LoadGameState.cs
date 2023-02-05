using Code.Domain.Data.Static;
using Code.Domain.Extensions;
using Code.Domain.Infrastructure.Interfaces;
using Code.Domain.Visualisation;
using Code.Interfaces;

namespace Code
{
    public class LoadGameState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ISceneLoadingVisualizer _sceneLoadingVisualizer;
        private readonly GameStaticData _gameStaticData;

        public LoadGameState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            ISceneLoadingVisualizer sceneLoadingVisualizer, GameStaticData gameStaticData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _sceneLoadingVisualizer = sceneLoadingVisualizer;
            _gameStaticData = gameStaticData;
        }
        
        public async void Enter()
        {
            var asyncOperation = _sceneLoader.LoadSceneAsync(_gameStaticData.MainMenuSceneName);
            _sceneLoadingVisualizer.StartVisualising(asyncOperation);
            await asyncOperation;
            _gameStateMachine.SwitchState<MainMenuState>();
        }

        public void Exit()
        {
        }
    }
}