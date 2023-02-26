using System.Collections.Generic;
using Entitas;

namespace Code.GamePlay.Systems
{
    public class PressurePlateSystem : ReactiveSystem<GameEntity>
    {
        public PressurePlateSystem(GameContext gameContext) : base(gameContext) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.Collided.AddedOrRemoved());

        protected override bool Filter(GameEntity entity)
            => entity.isPressurePlate && entity.hasConnectedEntity;
        

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var pressurePlate in entities)
            {
                UnityEngine.Debug.Log("Pressure plate system executed");
                
                var connectedEntity = pressurePlate.connectedEntity.Value;

                connectedEntity.isInteracted = pressurePlate.isCollided;
            }
        }
    }
}