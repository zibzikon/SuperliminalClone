using System.Threading.Tasks;
using Code.Domain.Infrastructure.Interfaces;
using UnityEngine;

namespace Code.Domain.Infrastructure
{
    public class LevelLoader : ILevelLoader
    {
        public AsyncOperation LevelLoadingAsyncOperation { get; private set; }
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelSceneLoadingContext _levelSceneLoadingContext;

        public LevelLoader(ISceneLoader sceneLoader, ILevelSceneLoadingContext levelSceneLoadingContext)
        {
            _sceneLoader = sceneLoader;
            _levelSceneLoadingContext = levelSceneLoadingContext;
        }
        
        public async Task LoadAsync(LevelData levelData)
        {
            _ = _sceneLoader.LoadSceneAsync(levelData.SceneName);
            
            LevelLoadingAsyncOperation = _sceneLoader.SceneLoadingAsyncOperation;
            
            var levelSceneContext = await WaitForLevelSceneLoaded();
            
            levelSceneContext.SetLevelData(levelData);
        }

        private Task<ILevelScene> WaitForLevelSceneLoaded()
        {
            var taskCompletionSource = new TaskCompletionSource<ILevelScene>();

            _levelSceneLoadingContext.LevelSceneContextChanged += result => { taskCompletionSource.SetResult(result); };
            
            return taskCompletionSource.Task;
        }
    }
}