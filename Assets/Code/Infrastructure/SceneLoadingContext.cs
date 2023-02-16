using System;
using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;

namespace Code.Infrastructure
{
    public class SceneLoadingContext : ISceneLoadingContext
    {
        private ISceneContext _sceneContext;
        public event Action<ISceneContext> NewSceneLoaded;

        public ISceneContext SceneContext
        {
            get => _sceneContext;
            set
            {
                _sceneContext = value;
                NewSceneLoaded?.Invoke(_sceneContext);
            }
        }
    }
}