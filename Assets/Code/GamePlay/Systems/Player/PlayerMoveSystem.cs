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
                GameMatcher.Player, Position, GameMatcher.Transform, MoveSpeed, GameMatcher.CharacterController));
            
            _keyboard = inputContext.GetGroup(AllOf(Keyboard, PlayerMotion));
        }
        
        public void Execute()
        {
            foreach (var player in _players)
            foreach (var keyboard in _keyboard)
            {
                var moveValue = keyboard.playerMotion.Value;
                
                var motion = CalculatePlayerMoveDirection(player, moveValue);

                var playerController = player.characterController.Value;
                playerController.Move(motion * Time.deltaTime);
                
                player.ReplaceMoveDirection(motion);
                //player.ReplacePosition(playerController.transform.position);
            }
        }
        
        private Vector3 CalculatePlayerMoveDirection(GameEntity player, Vector2 moveValue)
        {
            var xSpeed = player.moveSpeed.Value * moveValue.x;
            var ySpeed = player.moveSpeed.Value * moveValue.y;

            var right = player.transform.Value.right;
            var forward = player.transform.Value.forward;

            return (right * xSpeed + forward * ySpeed).WithNewY(player.moveDirection.Value.y);
        }
    }
}
