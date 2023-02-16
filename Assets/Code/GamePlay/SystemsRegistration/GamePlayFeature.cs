using Code.Game.Systems;
using Zenject;

namespace Code.Game.SystemsRegistration
{
    public class GamePlayFeature : InjectableFeature
    {
        public GamePlayFeature(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<PressurePlateSystem>();
            AddInjected<DoorSystem>();
        }
    }
}