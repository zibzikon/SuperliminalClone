using UnityEngine;

namespace Code.GamePlay.Behaviours
{
    [RequireComponent(typeof(UnityViewController))]
    public abstract class EntityBehaviour : MonoBehaviour
    {
        private UnityViewController _viewController;
        
        public GameEntity Entity => _viewController.Entity;
        
        private void Awake()
        {
            _viewController = GetComponent<UnityViewController>();
        }

        private void Start() => OnStart();

        protected virtual void OnStart() { }
    }
}