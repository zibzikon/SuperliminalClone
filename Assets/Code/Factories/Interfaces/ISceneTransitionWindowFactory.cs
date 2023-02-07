using Code.Domain.Data.Static;
using Code.Domain.UI.Interfaces;
using Code.Domain.Visualisation;

namespace Code.Domain.Factories
{
    public interface ISceneTransitionWindowFactory
    {
        SceneTransitionWindow Get(SceneTransitionType type);
    }
}