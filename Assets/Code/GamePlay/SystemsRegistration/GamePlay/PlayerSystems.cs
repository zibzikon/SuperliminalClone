using Code.GamePlay.Systems.Player;
using Zenject;

namespace Code.GamePlay.SystemsRegistration
{
    public class PlayerSystems : InjectableFeature
    {
        public PlayerSystems(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<EmitPlayerInput>();
            AddInjected<PlayerGravitySystem>();
            AddInjected<PlayerMoveSystem>();
            AddInjected<PlayerRotateSystem>();
            AddInjected<PlayerCameraRotateSystem>();
        }
    }
}