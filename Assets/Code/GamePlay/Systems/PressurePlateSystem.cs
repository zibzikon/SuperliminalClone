using Entitas;

namespace Code.GamePlay.Systems
{
    public class PressurePlateSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _pressurePlates;
        
        public PressurePlateSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _pressurePlates = gameContext.GetGroup(GameMatcher.PressurePlate);
        }
        
        public void Execute()
        {
            foreach (var pressurePlate in _pressurePlates)
            {
                if (!pressurePlate.hasConnectedEntity) continue;
              
                var connectedEntity = pressurePlate.connectedEntity.Value;
                
                if (!connectedEntity.isInteractable) continue;

                if (!pressurePlate.isCollided && connectedEntity.isInteracting)
                    connectedEntity.isInteracting = false;
                  
                else if (connectedEntity.isCollided && pressurePlate.hasCollisionID && !connectedEntity.isInteracting)
                    connectedEntity.isInteracting = true;
                
            }
        }
    }
}