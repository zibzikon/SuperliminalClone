using Code.Domain.Infrastructure;
using UnityEngine;
using Zenject;

namespace Code.Domain
{
    public class LevelSceneContext : MonoBehaviour , ILevelSceneContext
    {
        [Inject]
        public void Initialize(ILevelSceneContextContainer levelSceneContextContainer)
        {
            levelSceneContextContainer.LevelSceneContext = this;
        }
        
        public void SetLevelData(LevelData levelData)
        {
            
        }
    }
}