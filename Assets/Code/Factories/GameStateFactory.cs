using Code.Interfaces;
using Zenject;

namespace Code.Domain.Regestration.Installers
{
    public class GameStateFactory : IGameStateFactory
    {
        private readonly DiContainer _diContainer;

        public GameStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public T Get<T>() where T : IGameState
            => _diContainer.Instantiate<T>();
        
    }
}