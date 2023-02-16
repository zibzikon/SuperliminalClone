using Code.Mediators;
using UnityEngine;

namespace Code.UI.Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private TextButton _selectLevelButton;
        [SerializeField] private TextButton _continueButton;
        [SerializeField] private TextButton _exitGameButton;
        
        [SerializeField]private MainMediator _mediator;

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        
        private void RegisterEvents()
        {
            _selectLevelButton.Pressed += _mediator.ShowLevelSelectionMenu;
            _continueButton.Pressed += _mediator.ContinuePlaying;
            //_exitGameButton.Pressed += _mediator.ExitGame;
        }

        private void UnregisterEvents()
        {
            _selectLevelButton.Pressed -= _mediator.ShowLevelSelectionMenu;
            _continueButton.Pressed -= _mediator.ContinuePlaying;
            //_exitGameButton.Pressed -= _mediator.ExitGame;
        }
        
    }
}