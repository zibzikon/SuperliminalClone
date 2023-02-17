using Code.Extensions;
using Entitas;
using Zenject;

namespace Code.GamePlay.SystemsRegistration
{
    public abstract class InjectableFeature : Feature
    {
        private readonly DiContainer _diContainer;

        protected InjectableFeature(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        protected InjectableFeature AddInjected<T>() where T : ISystem
            => this.With(x => x.Add(_diContainer.Instantiate<T>()));
    }
}