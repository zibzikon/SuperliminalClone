using System;

namespace Code.Domain.Infrastructure
{
    public class LevelSceneContextContainer : ILevelSceneContextContainer
    {
        public event Action<ILevelSceneContext> LevelSceneContextChanged;

        public ILevelSceneContext LevelSceneContext
        {
            get => _levelSceneContext;
            set
            {
                _levelSceneContext = value;
                LevelSceneContextChanged?.Invoke(_levelSceneContext);
            }
        }
        
        private ILevelSceneContext _levelSceneContext;
    }
}