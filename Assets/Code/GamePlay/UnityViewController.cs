using Code.Attributes.Injection;
using Code.Game.Interfaces;
using Code.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Game.ViewVisteners
{
    [ImplicitInjectable]
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
            Entity.AddId(_identifierGenerator.GetNext());
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}