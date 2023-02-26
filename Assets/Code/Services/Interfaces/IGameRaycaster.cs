using Entitas;
using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface IGameRaycaster
    {
        bool TryGetEntityAtDirection(Vector3 origin ,Vector3 direction, out GameEntity entity);
        bool TryGetEntityAtDirection(Vector3 origin ,Vector3 direction, IMatcher<GameEntity> matcher, out GameEntity entity);
    }
}