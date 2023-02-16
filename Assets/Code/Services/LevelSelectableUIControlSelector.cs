using System;
using Code.Services.Interfaces;
using Code.UI.Windows;

namespace Code.Services
{
    public class LevelSelectableUIControlSelector : ILevelSelectableUIControlSelector
    {
        public event Action ControlSelected;
        public LevelSelectableUIControl SelectedControl { get; private set; }

        public void SelectLevelSelectableUIControl(LevelSelectableUIControl selectable)
        {
            SelectedControl?.Deselect();
            SelectedControl = selectable;
            SelectedControl.Select();
            
            ControlSelected?.Invoke();
        }
        
    }
}