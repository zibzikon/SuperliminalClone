using Code.Domain.Infrastructure.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Domain.Infrastructure
{
    public class SceneManagerBasedSceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName)
            => SceneManager.LoadScene(sceneName);

        public AsyncOperation LoadSceneAsync(string sceneName)
            => SceneManager.LoadSceneAsync(sceneName);
    }
}