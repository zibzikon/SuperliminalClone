using Code.Extensions;
using UnityEngine;

namespace Code.GamePlay.Behaviours
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