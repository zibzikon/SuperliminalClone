using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Data;
using Code.Data.ResourcesData;
using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;
using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class LevelLoader : ILevelLoader
    {
        public AsyncOperation LevelLoadingAsyncOperation { get; private set; }
        
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelSceneLoadingContext _levelSceneLoadingContext;
      
        private readonly Dictionary<int, string> _levelScenesNames;
        
        public LevelLoader(ISceneLoader sceneLoader, ILevelSceneLoadingContext levelSceneLoadingContext,
            IEnumerable<LevelResourceData> levelsResources)
        {
            _sceneLoader = sceneLoader;
            _levelSceneLoadingContext = levelSceneLoadingContext;
            
            _levelScenesNames = levelsResources.ToDictionary(x => x.Index, x => x.SceneName);
        }
        
        public virtual async Task LoadAsync(LevelData levelData)
        {
            _ = _sceneLoader.LoadSceneAsync(_levelScenesNames[levelData.Index]);
            
            LevelLoadingAsyncOperation = _sceneLoader.SceneLoadingAsyncOperation;
            
            var levelSceneContext = await WaitForLevelSceneLoaded();
            
            levelSceneContext.SetLevelData(levelData);
        }

        private Task<ILevelContext> WaitForLevelSceneLoaded()
        {
            var taskCompletionSource = new TaskCompletionSource<ILevelContext>();

            _levelSceneLoadingContext.LevelSceneContextChanged += result => { taskCompletionSource.SetResult(result); };
            
            return taskCompletionSource.Task;
        }
    }
}