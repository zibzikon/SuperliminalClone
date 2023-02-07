using System;

namespace Code.Domain.Infrastructure
{
    public class LevelSceneLoadingContext : ILevelSceneLoadingContext
    {
        public event Action<ILevelScene> LevelSceneContextChanged;

        public ILevelScene LevelScene
        {
            get => _levelScene;
            set
            {
                _levelScene = value;
                LevelSceneContextChanged?.Invoke(_levelScene);
            }
        }
        
        private ILevelScene _levelScene;
    }
}