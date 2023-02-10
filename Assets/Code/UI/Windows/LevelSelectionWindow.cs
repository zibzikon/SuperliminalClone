using System;
using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using Code.Factories.Interfaces.UI;
using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;
using Code.Mediators;
using UnityEngine;
using Zenject;
using LevelData = Code.Data.LevelData;

namespace Code.UI.Windows
{
    public class LevelSelectionWindow : MonoBehaviour
    {
        [SerializeField] private TextButton _playSelectedLevelButton;
        [SerializeField] private TextButton _moveBackButton;
        
        [SerializeField] private Transform _selectablesControlsParent;
        
        [SerializeField] private MainMediator _mediator;
        
        private ILevelSelectableUIControlFactory _levelSelectableUIControlFactory;
        
        private IEnumerable<LevelSelectableUIControl> _levelSelectorUIControls;
        private ILevelSelectableUIControlSelector _levelSelector;

        [Inject]
        public void Initialize(ILevelSelectableUIControlFactory levelSelectableUIControlFactory,
            ILevelSelectableUIControlSelector levelSelector, IGame game)
        {
            _levelSelector = levelSelector;
            Register();
            _levelSelectableUIControlFactory = levelSelectableUIControlFactory;
            
            InitializeView(game.Levels.Select(x => x.Value));
        }
        
        private void OnDestroy() => Unregister();

        private void InitializeView(IEnumerable<LevelData> levels)
        {
            _playSelectedLevelButton.Lock();
            
            _levelSelectorUIControls?.ForEach(Destroy);
            
            _levelSelectorUIControls = levels
                .Select(levelData => 
                    _levelSelectableUIControlFactory.Get(levelData, _mediator)
                    .With(x => x.transform.SetParent(_selectablesControlsParent))).ToList();
        }

        private void Register()
        {
            _levelSelector.ControlSelected += OnLevelSelected;
            _playSelectedLevelButton.Pressed += _mediator.PlaySelectedLevel;
            _moveBackButton.Pressed += _mediator.HideLevelSelectionMenu;
        }

        private void Unregister()
        {
            _levelSelector.ControlSelected -= OnLevelSelected;
            _playSelectedLevelButton.Pressed -= _mediator.PlaySelectedLevel;
            _moveBackButton.Pressed -= _mediator.HideLevelSelectionMenu;
        }

        private void OnLevelSelected() => _playSelectedLevelButton.Unlock();
    }
}