using Code.GamePlay.Systems;
using Code.GamePlay.Systems.Player;
using Zenject;

namespace Code.GamePlay.SystemsRegistration.GamePlay
{
    public class PlayerSystems : InjectableFeature
    {
        public PlayerSystems(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<EmitPlayerInput>();
            AddInjected<PlayerJumpSystem>();
            AddInjected<PlayerMoveSystem>();
            AddInjected<PlayerRotateSystem>();
            AddInjected<PlayerCameraRotateSystem>();
        }
    }
}