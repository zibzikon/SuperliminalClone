using Code.Extensions;
using Entitas;
using UnityEngine;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems.Player
{
    public class PlayerJumpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _keyboard;

        public PlayerJumpSystem(GameContext gameContext, InputContext inputContext)
        {
            _players = gameContext.GetGroup(AllOf(GameMatcher.Player, PhysicalObject, JumpForce));
            _keyboard = inputContext.GetGroup(AllOf(Keyboard));
        }
        
        public void Execute()
        {
            foreach (var player in _players)
            foreach (var keyboard in _keyboard)
            {

                if (keyboard.isPlayerJump && player.isGrounded)
                    player.ReplaceRigidbodyForce(player.jumpForce.Value.AsYVector3());
            }
        }
    }
}