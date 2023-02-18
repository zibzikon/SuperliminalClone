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
                .With(e => e.AddConnectedEntity(_connectedInteractable.Entity));
        }
    }
}