using System;
using Code.Infrastructure.Interfaces;
using Code.SceneManagement.Interfaces;

namespace Code.Infrastructure
{
    public class SceneLoadingContext : ISceneLoadingContext
    {
        private IScene _scene;
        public event Action<IScene> NewSceneLoaded;

        public IScene Scene
        {
            get => _scene;
            set
            {
                _scene = value;
                NewSceneLoaded?.Invoke(_scene);
            }
        }
    }
}