using Code.GamePlay.Systems;
using Zenject;

namespace Code.GamePlay.SystemsRegistration
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