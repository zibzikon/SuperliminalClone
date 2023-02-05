using Code.Domain.Mediators;
using Code.Interfaces;

namespace Code
{
    public class MainMenuState : IGameState
    {
        private readonly MainMediator _mainMediator;

        public MainMenuState(MainMediator mainMediator)
        {
            _mainMediator = mainMediator;
        }
        
        public void Enter()
        {
            _mainMediator.ShowMainMenu();
        }

        public void Exit()
        {
            _mainMediator.HideMainMenu();
        }
    }
}