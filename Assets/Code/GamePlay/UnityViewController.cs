using System;
using Code.Attributes.Injection;
using Code.Game.Interfaces;
using Code.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Game.ViewVisteners
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
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}