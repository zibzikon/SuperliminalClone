using Code.Extensions;
using Code.GamePlay.Interfaces;
using Code.GamePlay.Unity.Behaviours;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class InteractableListener : MonoBehaviour, IEventListener, IInteractedListener, IInteractedRemovedListener
    {
        [Required, SerializeField] private InteractableAnimator _animator;
        
        public void Register(GameEntity entity)
        {
            entity.AddInteractedListener(this);
            entity.AddInteractedRemovedListener(this);
        }
        public void Unregister(GameEntity entity)
        {
            entity.RemoveInteractedListener(this);
            entity.RemoveInteractedRemovedListener(this);
        }
        
        public void OnInteracted(GameEntity entity) => _animator.PlayEnterInteractionAnimation();
       
        public void OnInteractedRemoved(GameEntity entity) => _animator.PlayExitInteractionAnimation();

    }
}