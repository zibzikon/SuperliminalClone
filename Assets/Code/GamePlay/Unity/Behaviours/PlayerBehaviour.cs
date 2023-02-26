using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.GamePlay.Unity.Behaviours
{
    public class PlayerBehaviour : EntityBehaviour
    {
        [Required, SerializeField] private UnityViewController _connectedCamera;
        
        protected override void OnStart()
        {
            Entity.isPlayer = true;
            Entity.isSelector = true;
            Entity.isInteractor = true;
            Entity.isPhysicalObject = true;
            Entity.AddMoveSpeed(4f);
            Entity.AddJumpForce(0.3f);
            Entity.AddLookSpeed(2f);
            Entity.AddConnectedCamera(_connectedCamera.Entity);
                 
        }
    }
}