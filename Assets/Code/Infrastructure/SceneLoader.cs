using System.Threading.Tasks;
using Code.Domain.Extensions;
using Code.Domain.Infrastructure.Interfaces;
using Code.Domain.SceneManagement.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Domain.Infrastructure
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

        private Task<IScene> WaitForSceneLoaded()
        {
            var taskCompletionSource = new TaskCompletionSource<IScene>();
            _sceneLoadingContext.NewSceneLoaded += x => taskCompletionSource.SetResult(x);
            
            return taskCompletionSource.Task;
        }
        
    }
}