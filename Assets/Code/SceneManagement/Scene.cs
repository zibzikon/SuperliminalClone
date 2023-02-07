using Code.Domain.Infrastructure;
using Code.Domain.Mediators;
using Code.Domain.SceneManagement.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Domain.SceneManagement
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