using Zenject;

namespace Code.Game.SystemsRegistration
{
    public class GameEventsFeature : InjectableFeature
    {
        public GameEventsFeature(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<InteractedEventSystem>();
        }
    }
}