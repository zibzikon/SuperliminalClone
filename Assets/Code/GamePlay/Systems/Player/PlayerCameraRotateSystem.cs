using Code.Extensions;
using Entitas;
using UnityEngine;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems.Player
{
    public class PlayerCameraRotateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cameras;
        private readonly IGroup<InputEntity> _mouse;
        
        public PlayerCameraRotateSystem(GameContext gameContext, InputContext inputContext)
        {
            _cameras = gameContext.GetGroup(AllOf(PlayerCamera, Rotation, LookSpeed, LookXLimit));
            _mouse = inputContext.GetGroup(AllOf(Mouse, MouseAxis));
        }
        
        public void Execute()
        {
            foreach (var camera in _cameras)
            foreach (var mouse in _mouse)
            {
                var lookXLimit = camera.lookXLimit.Value;

                var xRotation = camera.rotation.Value.x;
                
                xRotation += -mouse.mouseAxis.Value.y * camera.lookSpeed.Value;
                
                var rotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit).AsXVector3();
                
                camera.ReplaceRotation(rotation);
            }
        }
    }
}