using System;
using Code.Domain.Infrastructure;
using Code.Domain.SceneManagement.Interfaces;

namespace Code.Domain.Regestration.Installers
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