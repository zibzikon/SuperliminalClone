using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Game.Contexts
{
    public class SceneContext : MonoBehaviour, ISceneContext
    {
        [Inject]
        public void Initialize(ISceneLoadingContext sceneLoadingContext)
        {
            sceneLoadingContext.SceneContext = this;
        }

    }
}