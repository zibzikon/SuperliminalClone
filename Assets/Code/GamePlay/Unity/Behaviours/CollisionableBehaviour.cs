namespace Code.GamePlay.Unity.Behaviours
{
    public class CollisionableBehaviour : EntityBehaviour
    {
        protected override void OnStart()
            => Entity.isCollisionable = true;
        
    }
}