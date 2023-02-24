using System;
using Code.Extensions;
using Sirenix.OdinInspector;

namespace Code.Debug.Code
{
    using UnityEngine;

    public class SweepTestExampla : MonoBehaviour
    {
        [SerializeField] private float collisionCheckDistance;
        [SerializeField, ReadOnly, HideInEditorMode] private bool aboutToCollide;
        [SerializeField, ReadOnly, HideInEditorMode] private float distanceToCollision;
        
        [SerializeField] private Transform _collisionVisualizer;
        
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            transform.position = CalculateNewPosition();
        }
        
        private Vector3 CalculateNewPosition()
        {
            const float MaxCalculationDistance = 100;

            var targetTransform = transform;
            var startPosition = targetTransform.localPosition;
            var nextPosition = startPosition;
           
            while (Vector3.Distance(startPosition, nextPosition) < MaxCalculationDistance)
            {
                
                if (CheckCollision(targetTransform, out var hit))
                {
                    targetTransform.position = startPosition;
                    _collisionVisualizer.transform.position = hit.point;
                    return transform.forward.Project(hit.point);
                }
                
                nextPosition = targetTransform.position + transform.forward * collisionCheckDistance;
                
                targetTransform.position = nextPosition;
            }

            throw new ApplicationException();
        }

        private bool CheckCollision(Transform targetTransform, out RaycastHit hit)
        {
            var up = targetTransform.up;
            var right = targetTransform.right;

            return _rigidbody.SweepTest(right, out hit, collisionCheckDistance)
                   || _rigidbody.SweepTest(-right, out hit, collisionCheckDistance)
                   || _rigidbody.SweepTest(up, out hit, collisionCheckDistance)
                   || _rigidbody.SweepTest(-up, out hit, collisionCheckDistance)
                   || _rigidbody.SweepTest(targetTransform.forward, out hit, collisionCheckDistance);
        }
    }
}