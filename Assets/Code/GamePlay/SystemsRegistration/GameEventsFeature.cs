using Zenject;

namespace Code.GamePlay.SystemsRegistration
{
    public class GameEventsFeature : InjectableFeature
    {
        public GameEventsFeature(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<InteractedEventSystem>();
        }
    }
}