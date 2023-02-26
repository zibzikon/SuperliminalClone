namespace Code.GamePlay.Unity.Behaviours
{
    public class CameraBehaviour : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity.isCamera = true;
            Entity.AddLookSpeed(2);
            Entity.AddLookXLimit(90);
            Entity.AddLastUpdatedPosition(transform.position);
        }
    }
}