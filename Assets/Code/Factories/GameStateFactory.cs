using Code.Factories.Interfaces;
using Code.StateMachine.Interfaces;
using Zenject;

namespace Code.Factories
{
    public class GameStateFactory : IGameStateFactory
    {
        private DiContainer DiContainer => ProjectContext.Instance.Container;
        
        public T Get<T>() where T : IGameState
            => DiContainer.Instantiate<T>();
    }
}