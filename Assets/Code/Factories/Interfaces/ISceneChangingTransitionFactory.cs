using Code.Domain.Data.Static;
using Code.Domain.Visualisation;

namespace Code.Domain.Factories
{
    public interface ISceneChangingTransitionFactory
    {
        ISceneChangingTransition Get(SceneChangingTransitionType type);
    }
}