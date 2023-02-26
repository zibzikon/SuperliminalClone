using System;
using Code.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.Behaviours
{
    public class GroundedBehaviour : EntityBehaviour
    {
        [SerializeField] private LayerMask _groundLayers;
        [Required, SerializeField] private Vector3 _feetPosition;
        
        private Collider[] _cachedColliders = new Collider[30];

        private void OnCollisionEnter(Collision collision) => TrySetGrounded(true);
        private void OnCollisionExit(Collision other) => TrySetGrounded(false);

        private void TrySetGrounded(bool value) => Entity.isGrounded = IsGrounded() && value;
        
        private bool IsGrounded()
        {
            const float checkingRadius = 0.05f;
            
            return Physics.OverlapSphereNonAlloc(_feetPosition + transform.position, checkingRadius, _cachedColliders, _groundLayers) > 0;
        }

    }
}