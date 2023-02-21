using Code.Extensions;

namespace Code.GamePlay.Behaviours
{
    public class PlayerCameraBehaviour : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity
                .With(x => x.isPlayerCamera = true)
                .With(x => x.AddRotation(transform.localRotation.eulerAngles))
                .With(x => x.AddLookSpeed(2))
                .With(x => x.AddLookXLimit(90));
        }
    }
}