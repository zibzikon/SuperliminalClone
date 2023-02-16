using Code.Extensions;

namespace Code.Game.Behaviours
{
    public class DoorBehaviour : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity
                .With(e => e.isDoor = true)
                .With(e => e.isInteractable = true);
        }
    }
}