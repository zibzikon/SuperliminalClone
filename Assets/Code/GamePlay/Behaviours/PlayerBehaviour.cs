using Code.Extensions;

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
                .With(x => x.AddLookSpeed(2f));
        }
    }
}