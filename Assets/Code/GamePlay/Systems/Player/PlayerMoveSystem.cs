using Code.Extensions;
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
                GameMatcher.Player, PhysicalObject, Position, GameMatcher.Transform, MoveSpeed));
            
            _keyboard = inputContext.GetGroup(AllOf(Keyboard, PlayerMotion));
        }
        
        public void Execute()
        {
            foreach (var player in _players)
            foreach (var keyboard in _keyboard)
            {
                var moveValue = keyboard.playerMotion.Value;
                
                var moveVelocity = CalculatePlayerMoveVelocity(player, moveValue);

                player.ReplaceRigidbodyVelocity(moveVelocity);
            }
        }
        
        private Vector3 CalculatePlayerMoveVelocity(GameEntity player, Vector2 moveValue)
        {
            var moveSpeed = player.moveSpeed.Value;
            
            var xSpeed = moveSpeed * moveValue.x;
            var ySpeed = moveSpeed * moveValue.y;

            var right = player.transform.Value.right;
            var forward = player.transform.Value.forward;

            return right * xSpeed + forward * ySpeed;
        }
    }
}
