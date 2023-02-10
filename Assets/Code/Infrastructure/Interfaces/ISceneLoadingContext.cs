using System;
using Code.SceneManagement.Interfaces;

namespace Code.Infrastructure.Interfaces
{
    public interface ISceneLoadingContext
    {
        event Action<IScene> NewSceneLoaded;
        IScene Scene { get; set; }
    }
}