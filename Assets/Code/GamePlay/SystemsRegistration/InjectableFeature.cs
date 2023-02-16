using Code.Extensions;
using Code.Game.Systems;
using Entitas;
using Zenject;

namespace Code.Game.SystemsRegistration
{
    public class InjectableFeature : Feature
    {
        private readonly DiContainer _diContainer;

        public InjectableFeature(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public InjectableFeature AddInjected<T>() where T : ISystem
            => this.With(x => x.Add(_diContainer.Instantiate<T>()));
    }
}