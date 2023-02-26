using System;
using Code.Data;
using Code.Extensions;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Code.GamePlay.Systems
{
    public class ForcedPerspectiveSystem : IExecuteSystem
    {
        private readonly CollisionData _collisionData;
        private readonly IGroup<GameEntity> _selectors;
        
        private readonly IMatcher<GameEntity> _forcedPerspectiveObjectMatcher =
            AllOf(Selectable, Selected, SelectionDistance, OriginalScale, ForcedPerspectiveObject, PhysicalObject, 
                 ObjectBounds, LastUpdatedPosition, Position, Rotation, Scale);
        
        private readonly IMatcher<GameEntity> _selectorCameraMatcher =
            AllOf(GameMatcher.Camera, LastUpdatedPosition, Position, Rotation, GameMatcher.Transform);
        
        private readonly Collider[] _cachedColliders = new Collider[30];
        
        public ForcedPerspectiveSystem(GameContext gameContext, CollisionData collisionData)
        {
            _collisionData = collisionData;
            _selectors = gameContext.GetGroup(AllOf(Selector, SelectedObject, ConnectedCamera));
 
        }
        
        public void Execute()
        {
            foreach (var selector in _selectors)
            {
                var selectorCamera = selector.connectedCamera.Value;
                var target = selector.selectedObject.Value;
                
                if(!_selectorCameraMatcher.Matches(selectorCamera)) continue;
                if (!_forcedPerspectiveObjectMatcher.Matches(target)) continue;

                UpdateTargetTransform(target, selectorCamera);
            }
        }
        
        private void UpdateTargetTransform(GameEntity target, GameEntity selectorCamera)
        {
            var position = selectorCamera.lastUpdatedPosition.Value;
            var orientation = selectorCamera.transform.Value.forward;
            var targetBounds = target.objectBounds.Value;
            var originalDistance = target.selectionDistance.Value;
            var originalScale = target.originalScale.Value;
            
            var newTargetPosition = CalculateNewPosition(position, orientation,
                targetBounds, originalDistance, originalScale);
            
            var scale = EvaluateSizeAtPosition(position, newTargetPosition, originalDistance, originalScale);

            target.ReplaceScale(scale);
            target.ReplacePosition(newTargetPosition);
            target.ReplaceRotation(orientation);
        }

        private Vector3 EvaluateSizeAtPosition(Vector3 selectorPosition, Vector3 targetPosition, float originalDistance, float originalScale)
        {
            var currentDistance = Vector3.Distance(selectorPosition, targetPosition);

            var ratio = currentDistance / originalDistance;

            return ratio.AsVector3() * originalScale;
        }

        private Vector3 CalculateNewPosition(Vector3 selectorPosition, Vector3 playerForwardOrientation,
            Bounds targetBounds, float originalDistance, float originalScale)
        {
            const float maxCalculationDistance = 1000;
            const float calculationsHardness = 0.1f;

            var nextPosition = selectorPosition;
            var position = selectorPosition;
            
            while (Vector3.Distance(selectorPosition, nextPosition) < maxCalculationDistance)
            {
                targetBounds.size = EvaluateSizeAtPosition(selectorPosition, position, originalDistance, originalScale);
                targetBounds.center = nextPosition;
                
                if (CheckCollision(targetBounds, 
                        Quaternion.Euler(playerForwardOrientation), _cachedColliders))
                    return position;

                position = nextPosition;
                nextPosition += playerForwardOrientation * calculationsHardness;
            }

            throw new ApplicationException();
        }

        private bool CheckCollision(Bounds bounds, Quaternion orientation, Collider[] colliders)
        {
            var center = bounds.center;
            var halfExtents = bounds.extents;

            var isCollide = Physics.OverlapBoxNonAlloc(center, halfExtents, colliders,
                orientation, _collisionData.CollisionableLayers) > 0;

            return isCollide;
        }
    }
    
}