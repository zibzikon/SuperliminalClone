using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Data;
using Code.Data.ResourcesData;
using Code.Infrastructure.Interfaces;
using Code.Visualisation.Interfaces;
using UnityEngine;

namespace Code.Infrastructure
{
    public class LevelLoaderWithLoadingVisualization : LevelLoader
    {
        private readonly ISceneLoadingVisualizer _sceneLoadingVisualizer;

        public LevelLoaderWithLoadingVisualization(ISceneLoader sceneLoader, ILevelSceneLoadingContext levelSceneLoadingContext,
            ISceneLoadingVisualizer sceneLoadingVisualizer, IEnumerable<LevelResourceData> levelsResources)
            : base(sceneLoader, levelSceneLoadingContext, levelsResources)
        {
            _sceneLoadingVisualizer = sceneLoadingVisualizer;
        }
        
        public override Task LoadAsync(LevelData levelData)
        {
            var task = base.LoadAsync(levelData);
            
            _sceneLoadingVisualizer.StartVisualising(LevelLoadingAsyncOperation);
            
            return task;
        }

    }
}
