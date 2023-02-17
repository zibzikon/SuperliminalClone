using Code.GamePlay;
using UnityEngine;

namespace Code.Infrastructure
{
    [RequireComponent(typeof(Collider))]
    public class ViewCollider : MonoBehaviour 
    {
        public Collider Collider { get; private set; }
        [field: SerializeField] public UnityViewController ViewController { get; }
    }
}