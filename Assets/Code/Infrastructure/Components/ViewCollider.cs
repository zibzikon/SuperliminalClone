using Code.GamePlay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Infrastructure.Components
{
    [RequireComponent(typeof(Collider))]
    public class ViewCollider : MonoBehaviour 
    {
        public Collider Collider { get; private set; }
        [field: Required, SerializeField] public UnityViewController ViewController { get; private set; }

        private void Awake()
            => Collider = GetComponent<Collider>();
    }
}