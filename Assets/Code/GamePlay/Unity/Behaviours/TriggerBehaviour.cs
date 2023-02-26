using System;
using Code.Extensions;
using Code.Infrastructure.Components;
using UnityEngine;

namespace Code.GamePlay.Unity.Behaviours
{
    public class TriggerBehaviour : EntityBehaviour
    {
        [SerializeField] private LayerMask _triggeringLayers;
        
        private void OnTriggerEnter(Collider other) => OnEnterCollision(other);
        
        private void OnTriggerExit(Collider other) => OnExitCollision(other);
        
        private void OnEnterCollision(Collider collider)
        {
            if (!TryGetEntity(collider, out var entity)) return;
            
            Entity.MarkCollidedBy(entity);
            entity.MarkCollidedBy(Entity);
        }

        private void OnExitCollision(Collider collider)
        {
            if (!TryGetEntity(collider, out var entity)) return;

            Entity.UnmarkCollided();
            entity.UnmarkCollided();
        }

        private bool TryGetEntity(Collider collider, out GameEntity entity)
        {
            entity = null;
            
            ViewCollider viewCollider;
            if (!collider.MatchLayer(_triggeringLayers) ||
                (viewCollider = collider.gameObject.GetComponent<ViewCollider>()) == null) return false;

            entity = viewCollider.ViewController.Entity;
            return true;
        }
        
    }
}
