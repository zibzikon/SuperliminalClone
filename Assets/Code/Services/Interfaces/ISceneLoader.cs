using System.Threading.Tasks;
using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface ISceneLoader
    {
        public AsyncOperation SceneLoadingAsyncOperation { get; }
        void LoadScene(string sceneName);
        Task LoadSceneAsync(string sceneName);
    }
}