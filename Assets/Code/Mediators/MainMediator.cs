using Code.Game.Interfaces;
using Code.Infrastructure;
using Code.Infrastructure.Interfaces;
using Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace Code.Mediators
{
    public class MainMediator : MonoBehaviour
    {
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        
        [SerializeField] private LevelSelectionWindow _levelSelectionWindow;

        private IGame _game;
        private ILevelSelectableUIControlSelector _levelSelector = new LevelSelectableUIControlSelector();
        private ILevelLoader _levelLoader;

        [Inject]
        public void Initialize(IGame game, ILevelLoader levelLoader, ILevelSelectableUIControlSelector levelSelector)
        {
            _game = game;
            _levelLoader = levelLoader;
            _levelSelector = levelSelector;
        }
        
        public void ShowMainMenuWindow() => _mainMenuWindow.gameObject.SetActive(true);
        
        public void HideMainMenuWindow() => _mainMenuWindow.gameObject.SetActive(false);

        public void ShowLevelSelectionMenu() => _levelSelectionWindow.gameObject.SetActive(true);
        
        public void HideLevelSelectionMenu() => _levelSelectionWindow.gameObject.SetActive(false);

        public async void ContinuePlaying() => await _levelLoader.LoadAsync(_game.LastUnlockedLevel);

        public void SelectLevelSelectableUIControl(LevelSelectableUIControl selectable) => _levelSelector.SelectLevelSelectableUIControl(selectable);

        public async void PlaySelectedLevel() => await _levelLoader.LoadAsync(_levelSelector.SelectedControl.LevelData);

    } 
}