using UnityEngine;

namespace Code.GamePlay.Unity.Behaviours
{
    [RequireComponent(typeof(UnityViewController))]
    public abstract class EntityBehaviour : MonoBehaviour
    {
        protected UnityViewController Controller { get; private set; }
        protected GameEntity Entity => Controller.Entity;
        
        private void Awake()
        {
            Controller = GetComponent<UnityViewController>();
        }

        private void Start() => OnStart();

        protected virtual void OnStart() { }
    }
}