using UnityEngine;

namespace Code.GamePlay.Behaviours
{
    public class InteractableAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _isInteractingKeyName;
        
        public void PlayEnterInteractionAnimation()
            => _animator.SetBool(_isInteractingKeyName, true);    
        
        public void PlayExitInteractionAnimation()
            => _animator.SetBool(_isInteractingKeyName, false);
    }
}