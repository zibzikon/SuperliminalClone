using Code.GamePlay.Systems;
using Code.GamePlay.Systems.Input;
using Zenject;

namespace Code.GamePlay.SystemsRegistration
{
    public class GamePlayFeature : InjectableFeature
    {
        public GamePlayFeature(DiContainer diContainer) : base(diContainer)
        {
            AddInjected<InitializeCursorSystem>();
            AddInjected<RegisterInputsSystem>();
            AddInjected<EmitInputSystem>();
            AddInjected<PlayerSystems>();
            AddInjected<PressurePlateSystem>();
        }
    }
}