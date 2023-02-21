using Entitas;
using UnityEngine;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems.Player
{
    public class PlayerMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _keyboard;

        public PlayerMoveSystem(GameContext gameContext, InputContext inputContext)
        {
            _players = gameContext.GetGroup(AllOf(
                GameMatcher.Player, Position, GameMatcher.Transform, MoveSpeed));
            
            _keyboard = inputContext.GetGroup(AllOf(Keyboard, PlayerMove));
        }
        
        public void Execute()
        {
            foreach (var player in _players)
            foreach (var keyboard in _keyboard)
            {
                var moveValue = keyboard.playerMove.Value;
                
                var xSpeed = player.moveSpeed.Value * moveValue.x;
                var ySpeed = player.moveSpeed.Value * moveValue.y;

                var right = player.transform.Value.right;
                var forward = player.transform.Value.forward;

                var moveDirection = right * xSpeed + forward * ySpeed;
                
                var nextPosition = player.position.Value + moveDirection * Time.deltaTime;
                
                if (nextPosition != player.position.Value)
                    player.ReplacePosition(nextPosition);
            }
        }
    }
}
