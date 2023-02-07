using System;
using Code.Domain.SceneManagement.Interfaces;

namespace Code.Domain.Infrastructure
{
    public interface ISceneLoadingContext
    {
        event Action<IScene> NewSceneLoaded;
        IScene Scene { get; set; }
    }
}