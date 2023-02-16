using Code.Extensions;
using Code.Game.ViewVisteners;
using UnityEngine;

namespace Code.Game.Behaviours
{
    public class PressurePlateBehaviour : EntityBehaviour
    {
        [SerializeField] private UnityViewController _connectedInteractable;
        protected override void OnStart()
        {
            Entity
                .With(e => e.isPressurePlate = true)
                .With(e => e.isInteractable = true)
                .With(e => e.AddConnectedEntityID(_connectedInteractable.Entity.id.Value));
        }
    }
}