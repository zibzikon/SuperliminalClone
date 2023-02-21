using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.ViewListeners
{
    public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
    {
        public void Register(GameEntity entity) => entity.AddPositionListener(this);

        public void Unregister(GameEntity entity) => entity.RemovePositionListener(this);

        public void OnPosition(GameEntity entity, Vector3 value)
            => transform.position = value;
    }
}