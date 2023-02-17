using System;
using Code.Extensions;
using Code.Infrastructure;
using UnityEngine;

namespace Code.GamePlay.Behaviours
{
    public class TriggerBehaviour : EntityBehaviour
    {
        private void OnTriggerEnter(Collider other) => MarkCollided(other);

        private void OnTriggerStay(Collider other) => MarkCollided(other);

        private void OnTriggerExit(Collider other) => UnmarkCollided(other);

        private void MarkCollided(Collider collider)
        {
            if (TryGetEntity(collider, out var entity)) return;

            Entity.MarkCollided(entity);
            entity.MarkCollided(Entity);
        }

        private static bool TryGetEntity(Collider collider, out GameEntity entity)
        {
            entity = null;
            
            ViewCollider viewCollider = null;
            if ((viewCollider = collider.GetComponent<ViewCollider>()) == null) return false;

            entity = viewCollider.ViewController.Entity;
            return false;
        }

        private void UnmarkCollided(Collider other)
        {
            ViewCollider viewCollider = null;
            if ((viewCollider = GetComponent<Collider>().GetComponent<ViewCollider>()) == null) return;
            
            var entity = viewCollider.ViewController.Entity;
                
            Entity.MarkCollided(entity);
            entity.MarkCollided(Entity);
        }
        
    }
}