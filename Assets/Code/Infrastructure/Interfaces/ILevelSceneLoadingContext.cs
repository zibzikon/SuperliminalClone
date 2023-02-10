using System;
using Code.SceneManagement.Interfaces;

namespace Code.Infrastructure.Interfaces
{
    public interface ILevelSceneLoadingContext
    {
        event Action<ILevelScene> LevelSceneContextChanged;
        ILevelScene LevelScene { get; set; }
        
    }
}