using Code.Extensions;
using Entitas;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems.Player
{
    public class PlayerRotateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        public PlayerRotateSystem(GameContext gameContext, InputContext inputContext)
        {
            _players = gameContext.GetGroup(AllOf(GameMatcher.Player, Rotation));
            _inputs = inputContext.GetGroup(AllOf(Mouse, MouseAxis));
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var player in _players)
            {
                var yRotation = player.rotation.Value.y + 
                    input.mouseAxis.Value.x * player.lookSpeed.Value;

               player.ReplaceRotation(yRotation.AsYVector3());
            }
        }
    }
}