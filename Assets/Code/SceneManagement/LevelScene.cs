using Code.Domain.Infrastructure;
using UnityEngine;
using Zenject;

namespace Code.Domain
{
    public class LevelScene : MonoBehaviour , ILevelScene
    {
        [Inject]
        public void Initialize(ILevelSceneLoadingContext levelSceneLoadingContext)
        {
            levelSceneLoadingContext.LevelScene = this;
        }
        
        public void SetLevelData(LevelData levelData)
        {
            
        }
    }
}