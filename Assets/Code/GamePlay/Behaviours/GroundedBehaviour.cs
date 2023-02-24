using Code.Extensions;
using UnityEngine;

namespace Code.GamePlay.Behaviours
{
    public class GroundedBehaviour : EntityBehaviour
    {
        [SerializeField] private LayerMask _groundLayers;

        private void OnCollisionEnter(Collision collision) => TrySetGrounded(collision, true);
        private void OnCollisionExit(Collision other) => TrySetGrounded(other,false);
        

        private void TrySetGrounded(Collision collision, bool value)
        {
            if(!collision.gameObject.MatchLayer(_groundLayers)) return;
            
            Entity.isGrounded = value;
        }
        
    }
}