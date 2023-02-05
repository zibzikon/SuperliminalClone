using System.Threading.Tasks;
using Code.Domain.Infrastructure.Interfaces;
using UnityEngine;

namespace Code.Domain.Infrastructure
{
    public class LevelLoader : ILevelLoader
    {
        public AsyncOperation LoadingAsyncOperation { get; private set; }
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelSceneContextContainer _levelSceneContextContainer;

        public LevelLoader(ISceneLoader sceneLoader, ILevelSceneContextContainer levelSceneContextContainer)
        {
            _sceneLoader = sceneLoader;
            _levelSceneContextContainer = levelSceneContextContainer;
        }
        
        
        public AsyncOperation LoadAsync(LevelData levelData)
        {
            var loadingSceneAsyncOperation = _sceneLoader.LoadSceneAsync(levelData.SceneName);
            
            LoadAsyncInternal(levelData);
            
            return loadingSceneAsyncOperation;
        }

        private async void LoadAsyncInternal(LevelData levelData)
        {
            var taskCompletionSource = new TaskCompletionSource<ILevelSceneContext>();

            _levelSceneContextContainer.LevelSceneContextChanged += result => { taskCompletionSource.SetResult(result); };
            var levelSceneContext = await taskCompletionSource.Task;
            
            levelSceneContext.SetLevelData(levelData);
        }
    }
}