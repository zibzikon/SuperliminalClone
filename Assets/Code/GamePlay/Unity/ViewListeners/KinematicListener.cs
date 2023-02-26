using Code.Extensions;
using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class KinematicListener : MonoBehaviour, IEventListener, IKinematicListener, IKinematicRemovedListener
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Register(GameEntity entity)
        {
            entity.AddKinematicListener(this);
            entity.AddKinematicRemovedListener(this);
        }
        
        public void Unregister(GameEntity entity)
        {
            entity.RemoveKinematicListener(this);
            entity.RemoveKinematicRemovedListener(this);
        }

        public void OnKinematic(GameEntity entity) => _rigidbody.isKinematic = true;

        public void OnKinematicRemoved(GameEntity entity) => _rigidbody.isKinematic = false;
    }
}