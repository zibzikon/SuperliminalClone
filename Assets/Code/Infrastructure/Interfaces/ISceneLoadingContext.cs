using System;
using Code.Game.Interfaces;

namespace Code.Infrastructure.Interfaces
{
    public interface ISceneLoadingContext
    {
        event Action<ISceneContext> NewSceneLoaded;
        ISceneContext SceneContext { get; set; }
    }
}