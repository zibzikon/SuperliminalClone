using System;
using System.Collections.Generic;
using System.Linq;
using Code.Attributes.Injection;
using Code.GamePlay.Interfaces;
using Code.GamePlay.Unity;
using Code.Infrastructure.Interfaces;
using Code.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.GamePlay
{
    [ImplicitInjectableView]
    public class UnityViewController : MonoBehaviour, IViewController
    {
        private IIdentifierGenerator _identifierGenerator;
        private IEntityComponentsUpdatersRegister _entityComponentsUpdatersRegister;
        public GameEntity Entity { get; private set; }

        public IEnumerable<Collider> Colliders { get; private set; }
        
        [Inject]
        public void Construct(IIdentifierGenerator identifierGenerator, IEntityComponentsUpdatersRegister entityComponentsUpdatersRegister)
        {
            _entityComponentsUpdatersRegister = entityComponentsUpdatersRegister;
            _identifierGenerator = identifierGenerator;
        }
        
        public void Initialize(GameEntity entity, GameContext context)
        {
            Entity = entity;
            RegisterColliders();
        }

        private void Start()
        {
            if (Entity is null)
            {
                throw new ApplicationException("View controller is not initialized, please initialize it before start");
            }
            
            Entity.AddId(_identifierGenerator.GetNext());
            
            RegisterViewComponents();
            RegisterEntityComponentsUpdaters();
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
        
        private void RegisterEntityComponentsUpdaters()
        {
            foreach (var updater in GetComponents<IEntityComponentUpdater>())
                _entityComponentsUpdatersRegister.Register(updater, Entity);
        }

        private void RegisterColliders()
        {
            var colliders = GetComponentsInChildren<Collider>().ToList();
            colliders.AddRange(GetComponents<Collider>());
            Colliders = colliders;
            
            if (colliders.Any())
                Entity.isCollisionable = true;
        }
    }
}