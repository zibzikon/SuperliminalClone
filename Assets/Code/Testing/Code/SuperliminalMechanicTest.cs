using System;
using Code.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Testing.Code
{
    public class SuperliminalMechanicTest : MonoBehaviour
    {
        [SerializeField] private float _calculationsHardness;
        [SerializeField] private LayerMask _notTargetLayerMask;
        [SerializeField] private LayerMask _targetLayerMask;

        private Transform _target;
        
        private float _originalDistance;
        private float _originalScale;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_target is null)
                    SelectObject();
                else
                    ReleaseTarget();
            }
            
            if (_target != null)
                UpdateTargetTransform();
            
        }

        private void SelectObject()
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit,1000, _targetLayerMask))
            {
                _target = hit.collider.gameObject.transform;
                _originalDistance = Vector3.Distance(transform.position, _target.transform.position);
                _originalScale = _target.localScale.x;
                _target.GetComponent<Collider>().enabled = false;
                _target.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        private void ReleaseTarget()
        {
            _originalScale = 0;
            _originalDistance = 0;
            _target.GetComponent<Collider>().enabled = true;
            _target.GetComponent<Rigidbody>().isKinematic = false;
            _target = null;

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

            return ratio.AsVector3() * _originalScale;
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