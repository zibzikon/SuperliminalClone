using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class RotationListener : MonoBehaviour, IEventListener, IRotationListener
    {
        public void Register(GameEntity entity) => entity.AddRotationListener(this);

        public void Unregister(GameEntity entity) => entity.RemoveRotationListener(this);

        public void OnRotation(GameEntity entity, Vector3 value) => transform.localRotation = Quaternion.Euler(value);
        
    }
}