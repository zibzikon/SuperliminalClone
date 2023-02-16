using Code.Data.ResourcesData.Enums;
using Code.UI.Windows;

namespace Code.Factories.Interfaces.UI
{
    public interface ISceneTransitionWindowFactory
    {
        SceneTransitionWindow Get(SceneTransitionType type);
    }
}