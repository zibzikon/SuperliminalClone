using UnityEngine;

namespace Code.Domain.Visualisation
{
    public interface ISceneLoadingVisualizer
    {
        void StartVisualising(AsyncOperation sceneLoadingAsyncOperation);
    }
}