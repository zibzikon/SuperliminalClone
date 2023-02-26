using Code.Extensions;
using Code.GamePlay.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class RigidbodyVelocityListener : MonoBehaviour, IEventListener, IRigidbodyVelocityListener
    {
        [Required, SerializeField] private Rigidbody _rigidbody;

        public void Register(GameEntity entity) => entity.AddRigidbodyVelocityListener(this);
        
        public void Unregister(GameEntity entity) => entity.RemoveRigidbodyVelocityListener(this);

        public void OnRigidbodyVelocity(GameEntity entity, Vector3 value)
            => _rigidbody.velocity = value.WithNewY(_rigidbody.velocity.y);
    }
}
