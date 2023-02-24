using Code.Services.Interfaces;
using Entitas;
using UnityEngine;
using static ControlActionType;

namespace Code.GamePlay.Systems.Player
{
    public class EmitPlayerInput : IExecuteSystem
    {
        private readonly IControlActions _controlActions;
        private readonly IUserInput _input;

        private IGroup<InputEntity> _keyboard;
        private IGroup<InputEntity> _mouse;
        
        public EmitPlayerInput(InputContext inputContext, IUserInput input, IControlActions controlActions)
        {
            _input = input;
            _controlActions = controlActions;
            _keyboard = inputContext.GetGroup(InputMatcher.Keyboard);
            _mouse = inputContext.GetGroup(InputMatcher.Mouse);
        }
        
        public void Execute()
        {
            foreach (var keyboard in _keyboard)  
            {
                var playerHorizontal = 0f;
                var playerVertical = 0f;
                
                if (IsAction(PlayerMoveForwards)) playerVertical += 1;
                if (IsAction(PlayerMoveBackwards)) playerVertical -= 1;
                if (IsAction(PlayerMoveLeft)) playerHorizontal -= 1;
                if (IsAction(PlayerMoveRight)) playerHorizontal += 1;
                
                keyboard.ReplacePlayerMotion(new Vector2(playerHorizontal, playerVertical));
                keyboard.isPlayerJump = IsAction(PlayerJump);
            }
        }
        
        private bool IsAction(ControlActionType actionType)
            => _input.IsKeyPressed(_controlActions.GetKeyCode(actionType));
    }
}