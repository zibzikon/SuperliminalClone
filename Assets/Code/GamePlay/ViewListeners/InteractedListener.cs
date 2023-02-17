using Code.GamePlay.Behaviours;
using Code.GamePlay.Interfaces;
using Entitas;
using UnityEngine;

namespace Code.GamePlay.ViewListeners
{
    public class InteractedListener : MonoBehaviour, IInteractedListener, IEventListener
    {
        [SerializeField] private InteractableAnimator _animator;

        private bool _interacted;
        
        public void Register(IEntity entity)
            => ((GameEntity)entity).AddInteractedListener(this);

        public void Unregister(IEntity entity)
            => ((GameEntity)entity).RemoveInteractedListener(this);

        public void OnInteracted(GameEntity entity)
        {
            _interacted = !_interacted;
            
            if (_interacted)
                _animator.PlayEnterInteractionAnimation();
            else
                _animator.PlayExitInteractionAnimation();
            
            entity.isInteracted = false;
        }
    }
}