using Code.Data;
using Code.Mediators;
using Code.UI.Windows;

namespace Code.Factories.Interfaces.UI
{
    public interface ILevelSelectableUIControlFactory
    {
        LevelSelectableUIControl Get(LevelData levelData, MainMediator mainMediator);
    }
}