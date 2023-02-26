using Code.Extensions;
using Entitas;
using UnityEngine;
using static GameMatcher;
using static InputMatcher;

namespace Code.GamePlay.Systems.Player
{
    public class PlayerCameraRotateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _mouse;

        private readonly IMatcher<GameEntity> _connectedCameraMatcher =
            AllOf(GameMatcher.Camera, Position, Rotation, LookSpeed, LookXLimit);
        
        public PlayerCameraRotateSystem(GameContext gameContext, InputContext inputContext)
        {
            _players = gameContext.GetGroup(AllOf(GameMatcher.Player, ConnectedCamera));
            _mouse = inputContext.GetGroup(AllOf(Mouse, MouseAxis));
        }
        
        public void Execute()
        {
            foreach (var player in _players)
            foreach (var mouse in _mouse)
            {
                var camera = player.connectedCamera.Value;

                if (!_connectedCameraMatcher.Matches(camera)) continue;

                var lookXLimit = camera.lookXLimit.Value;

                var xRotation = camera.rotation.Value.x;
                
                xRotation += -mouse.mouseAxis.Value.y * camera.lookSpeed.Value;
                
                var rotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit).AsXVector3();
                
                camera.ReplaceRotation(rotation);
            }
        }
    }
}