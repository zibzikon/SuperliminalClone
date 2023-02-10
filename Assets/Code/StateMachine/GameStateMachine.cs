using Code.Factories.Interfaces;
using Code.StateMachine.Interfaces;

namespace Code.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private IGameState _currentState;
        private readonly IGameStateFactory _gameStateFactory;
        
        public GameStateMachine(IGameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
        }

        public void SwitchState<T>() where T : IGameState
        {
            _currentState?.Exit();
            
            _currentState = _gameStateFactory.Get<T>();
            
            _currentState.Enter();
        }
    }
}