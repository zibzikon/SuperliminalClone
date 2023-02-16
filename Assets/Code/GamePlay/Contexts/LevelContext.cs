using Code.Data;
using Code.Game.Interfaces;
using Code.Infrastructure.Interfaces;
using Zenject;

namespace Code.Game.Contexts
{
    public class LevelContext : SceneContext, ILevelContext
    {
        [Inject]
        public void Initialize(ILevelSceneLoadingContext levelSceneLoadingContext)
        {
            levelSceneLoadingContext.LevelContext = this;
        }
        
        public void SetLevelData(LevelData levelData)
        {
            
        }
    }
}