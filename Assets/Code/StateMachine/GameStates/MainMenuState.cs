using Code.Domain;
using Code.Domain.Mediators;
using Code.Interfaces;

namespace Code
{
    public class MainMenuState : IGameState
    {
        private readonly IMainMenuFactory _mainMenuFactory;
        private IMainMenu _mainMenu;

        public MainMenuState(IMainMenuFactory mainMenuFactory)
        {
            _mainMenuFactory = mainMenuFactory;
        }
        
        public void Enter()
        {
            _mainMenu = _mainMenuFactory.Create();
            _mainMenu.Mediator.ShowMainMenu();
        }

        public void Exit()
        {
            _mainMenu.Mediator.HideMainMenu();
        }
    }
}