using System;
using Code.Game.Interfaces;

namespace Code.Infrastructure.Interfaces
{
    public interface ILevelSceneLoadingContext
    {
        event Action<ILevelContext> LevelSceneContextChanged;
        ILevelContext LevelContext { get; set; }
        
    }
}