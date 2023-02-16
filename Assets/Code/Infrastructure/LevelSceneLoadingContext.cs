using System;
using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;

namespace Code.Infrastructure
{
    public class LevelSceneLoadingContext : ILevelSceneLoadingContext
    {
        public event Action<ILevelContext> LevelSceneContextChanged;

        public ILevelContext LevelContext
        {
            get => _levelContext;
            set
            {
                _levelContext = value;
                LevelSceneContextChanged?.Invoke(_levelContext);
            }
        }
        
        private ILevelContext _levelContext;
    }
}