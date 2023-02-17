using Zenject;

namespace Code.Game.SystemsRegistration
{
    public class FullGameFeature : InjectableFeature
    {
        public FullGameFeature(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<GamePlayFeature>();
            AddInjected<GameEventsFeature>();
        }
    }
}