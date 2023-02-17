using Entitas;

namespace Code.GamePlay.Systems
{
    public class DoorSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _doors;

        public DoorSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _doors = _gameContext.GetGroup(GameMatcher.Door);
        }
        
        public void Execute()
        {
            foreach (var door in _doors)
            {
                if (door.isInteractable && door.isInteracting)
                {
                    
                }
            }
        }
    }
}