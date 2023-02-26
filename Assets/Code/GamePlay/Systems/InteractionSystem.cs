using System.Collections.Generic;
using Code.Extensions;
using Code.Services.Interfaces;
using Entitas;
using UnityEngine;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems
{
    public class InteractionSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGameRaycaster _raycaster;
        private IGroup<GameEntity> _interactors;

        public InteractionSystem(InputContext context, GameContext gameContext, IGameRaycaster gameRaycaster) : base(context)
        {
            _raycaster = gameRaycaster;
            _interactors = gameContext.GetGroup(Interactor);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(PlayerInteract.Added());

        protected override bool Filter(InputEntity entity) => true;

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var interactor in _interactors)
            {
                interactor.isInteracted = !interactor.isInteracted;
                Debug.Log("Interacted");
            }
            
        }
    }
}