using Code.Interfaces;
using Zenject;

namespace Code.Domain.Regestration.Installers
{
    public class GameStateFactory : IGameStateFactory
    {
        private DiContainer DiContainer => ProjectContext.Instance.Container;
        
        public T Get<T>() where T : IGameState
            => DiContainer.Instantiate<T>();
    }
}