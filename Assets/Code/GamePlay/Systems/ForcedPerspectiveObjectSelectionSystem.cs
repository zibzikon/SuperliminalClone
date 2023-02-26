using System.Collections.Generic;
using Code.Services.Interfaces;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Code.GamePlay.Systems
{
    public class ForcedPerspectiveObjectSelectionSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGameRaycaster _gameRaycaster;

        private readonly IMatcher<GameEntity> _forcedPerspectiveObjectMatcher =
            AllOf(Selectable, Interactable, ForcedPerspectiveObject, PhysicalObject, LastUpdatedPosition, Scale);

        private readonly IMatcher<GameEntity> _connectedCameraMatcher =
            AllOf(GameMatcher.Camera, LastUpdatedPosition, Position, Rotation, LookSpeed, LookXLimit);

        public ForcedPerspectiveObjectSelectionSystem(GameContext context, IGameRaycaster gameRaycaster) : base(context)
        {
            _gameRaycaster = gameRaycaster;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(Interacted.AddedOrRemoved());

        protected override bool Filter(GameEntity entity)
            => AllOf(Selector, Interactor, ConnectedCamera, Position).Matches(entity); 
        
        protected override void Execute(List<GameEntity> interactors)
        {
            foreach (var interactor in interactors)
            {
                if (interactor.hasSelectedObject)
                {
                    var selectedObject = interactor.selectedObject.Value;
                    
                    if (!_forcedPerspectiveObjectMatcher.Matches(selectedObject)) return;

                    DeselectObject(interactor, selectedObject);

                    return;
                }

                var connectedCamera = interactor.connectedCamera.Value;
                
                if(!_connectedCameraMatcher.Matches(connectedCamera)) return;
                
                if(!_gameRaycaster.TryGetEntityAtDirection(connectedCamera.lastUpdatedPosition.Value, 
                       connectedCamera.transform.Value.forward, _forcedPerspectiveObjectMatcher, out var selectable)) return;

                SelectObject(interactor, connectedCamera , selectable);
            }
        }

        private static void SelectObject(GameEntity interactor, GameEntity connectedCamera, GameEntity selectable)
        {
            interactor.AddSelectedObject(selectable);

            selectable.AddSelectionDistance(Vector3.Distance(selectable.lastUpdatedPosition.Value,
                connectedCamera.lastUpdatedPosition.Value));
            
            selectable.AddOriginalScale(selectable.scale.Value.x);
            
            interactor.isInInteraction = true;
            
            selectable.isSelected = true;
            selectable.isKinematic = true;
            selectable.isCollidersDisabled = true;
        }

        private static void DeselectObject(GameEntity interactor, GameEntity selectedObject)
        {
            interactor.RemoveSelectedObject();
            selectedObject.RemoveSelectionDistance();
            selectedObject.RemoveOriginalScale();
            
            interactor.isInInteraction = false;

            selectedObject.isSelected = false;
            selectedObject.isKinematic = false;
            selectedObject.isCollidersDisabled = false;

        }
    }
}