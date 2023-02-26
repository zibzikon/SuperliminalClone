using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.Behaviours
{
    public class PressurePlateBehaviour : EntityBehaviour
    {
        [Required, SerializeField] private UnityViewController _connectedInteractable;
        protected override void OnStart()
        {
            Entity.isPressurePlate = true;
            Entity.isCollisionable = true;
            Entity.AddConnectedEntity(_connectedInteractable.Entity);
        }
    }
}