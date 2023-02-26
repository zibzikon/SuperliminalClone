using Code.Extensions;
using Code.GamePlay.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class RigidbodyForceListener : MonoBehaviour, IEventListener, IRigidbodyForceListener
    {
        [Required, SerializeField] private Rigidbody _rigidbody;

        public void Register(GameEntity entity) => entity.AddRigidbodyForceListener(this);

        public void Unregister(GameEntity entity) => entity.RemoveRigidbodyForceListener(this);

        public void OnRigidbodyForce(GameEntity entity, Vector3 value) => _rigidbody.AddForce(value, ForceMode.Impulse);
        
    }
}
