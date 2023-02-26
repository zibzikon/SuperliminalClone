using Code.Services;
using Code.Services.Interfaces;
using Entitas;
using UnityEngine;
using static Code.Services.ControlActionType;

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
            foreach (var mouse in _mouse)
            {
                mouse.isPlayerInteract = IsAction(PlayerInteract);
                keyboard.isPlayerJump = IsAction(PlayerJump);
                
                var motion = CalculatePlayerMotion();
                if(!keyboard.hasPlayerMotion || keyboard.hasPlayerMotion && motion != keyboard.playerMotion.Value)
                    keyboard.ReplacePlayerMotion(motion);
            }
        }
        
        private bool IsAction(ControlActionType actionType)
            => _input.IsKeyPressed(_controlActions.GetKeyCode(actionType));

        private Vector2 CalculatePlayerMotion()
        {
            var playerHorizontal = 0f;
            var playerVertical = 0f;

            if (IsAction(PlayerMoveForwards)) playerVertical += 1;
            if (IsAction(PlayerMoveBackwards)) playerVertical -= 1;
            if (IsAction(PlayerMoveLeft)) playerHorizontal -= 1;
            if (IsAction(PlayerMoveRight)) playerHorizontal += 1;
            
            return new(playerHorizontal, playerVertical);
        }
    }
}