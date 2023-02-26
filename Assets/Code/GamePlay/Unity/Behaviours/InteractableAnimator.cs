using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.Behaviours
{
    public class InteractableAnimator : MonoBehaviour
    {
        [Required, SerializeField] private Animator _animator;
        [Required, SerializeField] private string _isInteractingKeyName;
        
        public void PlayEnterInteractionAnimation()
            => _animator.SetBool(_isInteractingKeyName, true);    
        
        public void PlayExitInteractionAnimation()
            => _animator.SetBool(_isInteractingKeyName, false);
    }
}