namespace Code.GamePlay.Unity.Behaviours
{
    public class ForcedPerspectiveObjectBehaviour : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity.isForcedPerspectiveObject = true;
            Entity.isInteractable = true;
            Entity.isSelectable = true;
            Entity.isPhysicalObject = true;
            Entity.AddMaxInteractionDistance(50);
            Entity.AddLastUpdatedPosition(transform.position);
        } 
    }
}