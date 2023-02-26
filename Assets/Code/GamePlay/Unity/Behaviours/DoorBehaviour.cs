namespace Code.GamePlay.Unity.Behaviours
{
    public class DoorBehaviour : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity.isDoor = true;
            Entity.isInteractable = true;
        }
    }
}