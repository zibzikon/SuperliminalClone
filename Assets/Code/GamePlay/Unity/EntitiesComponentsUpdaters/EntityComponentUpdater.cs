using UnityEngine;

namespace Code.GamePlay.Unity
{
    public abstract class EntityComponentUpdater : MonoBehaviour, IEntityComponentUpdater
    {
        public abstract void OnUpdate(GameEntity entity);
    }
}