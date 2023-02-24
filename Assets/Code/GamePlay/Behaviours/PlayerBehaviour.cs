using Code.Extensions;
using UnityEngine;

namespace Code.GamePlay.Behaviours
{
    public class PlayerBehaviour : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity
                .With(x => x.isPlayer = true)
                .With(x => x.AddPosition(transform.position))
                .With(x => x.AddRotation(transform.rotation.eulerAngles))
                .With(x => x.AddMoveSpeed(6f))
                .With(x => x.AddMoveDirection(Vector3.zero))
                .With(x => x.AddJumpForce(8f))
                .With(x => x.AddGravityForce(8f))
                .With(x => x.AddLookSpeed(2f));
        }
    }
}