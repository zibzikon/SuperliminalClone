using Entitas;

namespace Code.Game.Systems
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
                if (!pressurePlate.isInteractable || !pressurePlate.isInteracted ||
                    !pressurePlate.hasConnectedEntityID) continue;
                
                var connectedEntity = _gameContext.GetEntityWithId(pressurePlate.connectedEntityID.Value);
                 
                if (connectedEntity.isInteractable) connectedEntity.isInteracted = true;
            }
        }
    }
}