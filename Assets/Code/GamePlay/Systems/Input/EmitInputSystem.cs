using Code.GamePlay.Components;
using Code.Services.Interfaces;
using Entitas;
using UnityEngine;
using static Code.Services.ControlActionType;

namespace Code.GamePlay.Systems.Input
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IUserInput _input;

        private IGroup<InputEntity> _keyboard;
        private IGroup<InputEntity> _mouse;
        
        public EmitInputSystem(InputContext inputContext, IUserInput input)
        {
            _input = input;
            
            _keyboard = inputContext.GetGroup(InputMatcher.Keyboard);
            _mouse = inputContext.GetGroup(InputMatcher.Mouse);
        }
        
        public void Execute()
        {
            foreach (var mouse in _mouse)
            foreach (var keyboard in _keyboard)
            {
                var mouseAxis = _input.GetMouseAxis();
                mouse.ReplaceMouseAxis(mouseAxis);

                mouse.isLeftMouse = _input.IsLeftMousePressed();
                mouse.isRightMouse = _input.IsRightMousePressed();
            }
        }
    }
} 