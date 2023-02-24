using System;
using System.Linq;
using Code.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Debug.Code
{
    public class SuperliminalMechanicTest : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _calculationsHardness;
        [SerializeField] private LayerMask _notTargetLayerMask;

        private float _originalScale;
        private float _originalDistance;

        private void Start()
        {
            _originalDistance = Vector3.Distance(transform.position, _target.transform.position);
            _originalScale = _target.transform.localScale.x;
        }

        private void Update()
        {
            UpdateTargetTransform();
        }

        [Button, HideInEditorMode]
        private void UpdateTargetTransform()
        {
            var position = CalculateNewPosition();
            var scale = EvaluateSizeAtPosition(position);

            _target.transform.localScale = scale;
            _target.transform.position = position;
        }

        private Vector3 EvaluateSizeAtPosition(Vector3 position)
        {
            var currentDistance = Vector3.Distance(transform.position, position);

            var ratio = currentDistance / _originalDistance;

            return ratio.AsVector3();
        }


        private Vector3 CalculateNewPosition()
        {
            const float maxCalculationDistance = 1000;

            var startPosition = transform.position;
            var nextPosition = startPosition;
            var position = startPosition;
            var bounds = _target.GetComponent<Collider>().bounds;
            var collisionColliders = new Collider[30];
            
            while (Vector3.Distance(startPosition, nextPosition) < maxCalculationDistance)
            {
                bounds.size = EvaluateSizeAtPosition(nextPosition);
                bounds.center = nextPosition;
                
                if (CheckCollision(bounds, Quaternion.Euler(transform.forward), collisionColliders))
                    return position;

                position = nextPosition;
                nextPosition += transform.forward * _calculationsHardness;
            }

            throw new ApplicationException();
        }

        private bool CheckCollision(Bounds bounds, Quaternion orientation, Collider[] colliders)
        {
            var center = bounds.center;
            var halfExtents = bounds.extents;

            var isCollide = Physics.OverlapBoxNonAlloc(center, halfExtents, colliders, orientation, _notTargetLayerMask) > 0;

            return isCollide;
        }
           
        
    }
}