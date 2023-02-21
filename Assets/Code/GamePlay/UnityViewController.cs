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
        public GameEntity Entity { get; private set; }

        [Inject]
        public void Construct(IIdentifierGenerator identifierGenerator)
        {
            _identifierGenerator = identifierGenerator;
        }
        
        public void Initialize(GameEntity entity, GameContext context)
        {
            Entity = entity;
        }

        private void Start()
        {
            Entity.AddId(_identifierGenerator.GetNext());
            
            RegisterViewComponents();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void RegisterViewComponents()
        {
            foreach (var register in GetComponents<IViewComponentRegister>())
                register.Register(Entity);
        }
    }
}