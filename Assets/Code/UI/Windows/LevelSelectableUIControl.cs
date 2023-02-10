using System;
using Code.Data;
using Code.Data.ResourcesData.Enums;
using Code.Mediators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows
{
    public class LevelSelectableUIControl : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _foregroundImage;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _onSelectedImage;
        
        [SerializeField] private Color _unlockedBackgroundColor = Color.white;
        [SerializeField] private Color _lockedBackgroundColor = new (0.15f, 0.15f, 0.15f);
        
        private MainMediator _mediator;

        public LevelData LevelData { get; private set; }

        public void InitializeView(LevelData levelData, MainMediator mediator, Sprite previewSprite)
        {
            LevelData = levelData;
            _mediator = mediator;
            
            UpdateView(levelData, previewSprite);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _mediator.SelectLevelSelectableUIControl(this);
        }

        public void Select() => _onSelectedImage.enabled = true;
        
        public void Deselect() => _onSelectedImage.enabled = false;
        
        private void UpdateView(LevelData levelData, Sprite previewSprite)
        {
            _backgroundImage.sprite = previewSprite;

            switch (levelData.State)
            {
                case LevelState.Locked:
                    SetLockedView();
                    break;
                case LevelState.Unlocked:
                    SetUnlockedView();
                    break;
                case LevelState.Explored:
                    SetExploredView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetLockedView()
        {
            _foregroundImage.enabled = true;
            _backgroundImage.color = _lockedBackgroundColor;
        }
        
        private void SetUnlockedView()
        {
            _foregroundImage.enabled = false;
            _backgroundImage.color = _unlockedBackgroundColor;
        }
        
        private void SetExploredView()
        {
            _foregroundImage.enabled = false;
            _backgroundImage.color = _unlockedBackgroundColor;
        }
        
    }
}