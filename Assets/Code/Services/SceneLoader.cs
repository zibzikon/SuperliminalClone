using System.Threading.Tasks;
using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;
using Code.Services.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ISceneLoadingContext _sceneLoadingContext;
        public AsyncOperation SceneLoadingAsyncOperation { get; private set; }

        public SceneLoader(ISceneLoadingContext sceneLoadingContext)
        {
            _sceneLoadingContext = sceneLoadingContext;
        }
        
        public void LoadScene(string sceneName)
            => SceneManager.LoadScene(sceneName);

        public async Task LoadSceneAsync(string sceneName)
        {
            SceneLoadingAsyncOperation = SceneManager.LoadSceneAsync(sceneName);

            await WaitForSceneLoaded();
            SceneLoadingAsyncOperation = null;
        }

        private Task<ISceneContext> WaitForSceneLoaded()
        {
            var taskCompletionSource = new TaskCompletionSource<ISceneContext>();
            _sceneLoadingContext.NewSceneLoaded += x => taskCompletionSource.SetResult(x);
            
            return taskCompletionSource.Task;
        }
        
    }
}