using Code.Extensions;
using Entitas;
using UnityEngine;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems.Player
{
    public class PlayerGravitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _keyboard;

        public PlayerGravitySystem(GameContext gameContext, InputContext inputContext)
        {
            _players = gameContext.GetGroup(AllOf(GameMatcher.Player, MoveDirection, JumpForce, GravityForce));
            _keyboard = inputContext.GetGroup(AllOf(Keyboard));
        }
        
        public void Execute()
        {
            foreach (var player in _players)
            foreach (var keyboard in _keyboard)
            {
                var moveDirection = player.moveDirection.Value;

                if (keyboard.isPlayerJump && player.isGrounded)
                    moveDirection.y = player.jumpForce.Value;
                else if (!player.isGrounded)
                    moveDirection.y -= player.gravityForce.Value * Time.deltaTime;
                else 
                    moveDirection.WithNewY(0);
                
                
                player.ReplaceMoveDirection(moveDirection);
            }
        }
    }
}