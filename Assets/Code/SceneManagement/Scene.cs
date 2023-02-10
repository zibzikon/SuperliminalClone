using Code.Infrastructure.Interfaces;
using Code.SceneManagement.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.SceneManagement
{
    public class Scene : MonoBehaviour, IScene
    {
        private ISceneLoadingContext _sceneLoadingContext;

        [Inject]
        public void Initialize(ISceneLoadingContext sceneLoadingContext)
        {
            _sceneLoadingContext = sceneLoadingContext;
        }

        private void Start()
        {
            _sceneLoadingContext.Scene = this;
        }
    }
}