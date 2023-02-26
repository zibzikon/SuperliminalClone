using Code.Infrastructure;
using Code.Infrastructure.Components;
using Code.Services.Interfaces;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Code.Services
{
    public class GameRaycaster : IGameRaycaster
    {
        private const float MaxRaycastDistance = 500;
        
        public bool TryGetEntityAtDirection(Vector3 origin, Vector3 direction, out GameEntity entity)
        {
            entity = null;

            if (!Physics.Raycast(origin, direction, out var hit, MaxRaycastDistance)) return false;

            var hittedObject = hit.collider.gameObject;
            var viewCollider = hittedObject.GetComponent<ViewCollider>();
            
            Debug.Log(hittedObject.name + "Hitted");
            
            if (viewCollider is null) return false;
                
            entity = viewCollider.ViewController.Entity;
            
            return true;

        }

        public bool TryGetEntityAtDirection(Vector3 origin, Vector3 direction, IMatcher<GameEntity> matcher, out GameEntity entity)
            => TryGetEntityAtDirection(origin, direction, out entity) && matcher.Matches(entity);
        
    }
}