using System;
using Code.UI.Windows;

namespace Code.Infrastructure.Interfaces
{
    public interface ILevelSelectableUIControlSelector
    {
        event Action ControlSelected;
        LevelSelectableUIControl SelectedControl { get; }
        void SelectLevelSelectableUIControl(LevelSelectableUIControl selectable);
    }
}