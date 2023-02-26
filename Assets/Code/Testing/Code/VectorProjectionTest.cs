using Code.Extensions;
using UnityEngine;

namespace Code.Testing.Code
{
    public class VectorProjectionTest : MonoBehaviour
    {
        [SerializeField] private Vector3 _a, _b, _c;
        
        private  void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_a,  _b);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_a,  _c);
            Gizmos.color = Color.green;
            var projected = (_b - _a).Project(_c - _a) + _a;
            Gizmos.DrawLine(_a, projected);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(_b, projected);
            Gizmos.color = Color.white;
        }

        
    }
}