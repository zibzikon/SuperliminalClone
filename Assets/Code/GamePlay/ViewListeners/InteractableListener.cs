using Code.GamePlay.Behaviours;
using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.ViewListeners
{
    public class InteractableListener : MonoBehaviour, IInteractionListener, IEventListener
    {
        [SerializeField] private InteractableAnimator _animator;
        
        public void Register(GameEntity entity)
            => entity.AddInteractionListener(this);

        public void Unregister(GameEntity entity)
            =>entity.RemoveInteractionListener(this);
        
        public void OnInteraction(GameEntity entity, bool interacted)
        {
            if (interacted)
                _animator.PlayEnterInteractionAnimation();
            else
                _animator.PlayExitInteractionAnimation();
        }
    }
}