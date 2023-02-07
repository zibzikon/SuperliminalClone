using System;

namespace Code.Domain.Infrastructure
{
    public interface ILevelSceneLoadingContext
    {
        event Action<ILevelScene> LevelSceneContextChanged;
        ILevelScene LevelScene { get; set; }
        
    }
}