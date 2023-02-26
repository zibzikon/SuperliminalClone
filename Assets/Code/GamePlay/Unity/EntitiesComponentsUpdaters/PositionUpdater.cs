namespace Code.GamePlay.Unity
{
    public class PositionUpdater : EntityComponentUpdater
    {
        public override void OnUpdate(GameEntity entity)
            => entity.ReplaceLastUpdatedPosition(transform.position);
    }
} 