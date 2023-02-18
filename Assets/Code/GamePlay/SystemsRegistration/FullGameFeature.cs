using Zenject;

namespace Code.GamePlay.SystemsRegistration
{
    public class FullGameFeature : InjectableFeature
    {
        public FullGameFeature(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<GamePlayFeature>();
            AddInjected<GameEventSystems>();
        }
    }
}