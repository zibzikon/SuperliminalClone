using Code.Data;
using Code.Infrastructure.Interfaces;
using Code.SceneManagement.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.SceneManagement
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