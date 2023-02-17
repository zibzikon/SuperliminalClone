using Code.Attributes.Injection;
using Code.GamePlay.Interfaces;
using Code.Infrastructure;
using Code.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.GamePlay
{
    [ImplicitInjectableView]
    public class UnityViewController : MonoBehaviour, IViewController
    {
        private IIdentifierGenerator _identifierGenerator;
        private IViewsCollidersRegister _viewsCollidersRegister;
        public GameEntity Entity { get; private set; }

        [Inject]
        public void Construct(IIdentifierGenerator identifierGenerator, IViewsCollidersRegister viewsCollidersRegister)
        {
            _viewsCollidersRegister = viewsCollidersRegister;
            _identifierGenerator = identifierGenerator;
        }
        
        public void Initialize(GameEntity entity, GameContext context)
        {
            Entity = entity;
        }

        private void Start()
        {
            Entity.AddId(_identifierGenerator.GetNext());
            RegisterColliders();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void RegisterColliders()
        {
            var collisions = GetComponentsInChildren<ViewCollider>();
            
            foreach (var viewCollider in collisions)
                _viewsCollidersRegister.Register(Entity.id.Value, viewCollider);
        }
    }
}