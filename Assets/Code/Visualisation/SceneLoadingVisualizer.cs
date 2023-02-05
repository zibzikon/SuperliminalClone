using System;
using System.Threading.Tasks;
using Code.Domain.Data.Static;
using Code.Domain.Extensions;
using Code.Domain.Factories;
using UnityEngine;

namespace Code.Domain.Visualisation
{
    public class SceneLoadingVisualizer : ISceneLoadingVisualizer
    {
        private readonly ISceneChangingTransitionFactory _transitionFactory;

        public SceneLoadingVisualizer(ISceneChangingTransitionFactory transitionFactory)
        {
            _transitionFactory = transitionFactory;
        }
        
        public async void StartVisualising(AsyncOperation sceneLoadingAsyncOperation)
        {
            sceneLoadingAsyncOperation.allowSceneActivation = false;

            var transition = GetRandomTransition();
            await transition.EnterTransitionAsync();

            sceneLoadingAsyncOperation.allowSceneActivation = true;

            while (!sceneLoadingAsyncOperation.isDone)
            {
                transition.SetProgress(Mathf.RoundToInt(sceneLoadingAsyncOperation.progress * 100));
                await Task.Yield();
            }

            await transition.EnterTransitionAsync();
        }

        private ISceneChangingTransition GetRandomTransition()
        => _transitionFactory.Get((SceneChangingTransitionType)Enum
                .GetValues(typeof(SceneChangingTransitionType))
                .ToTypedEnumerable<int>()
                .SelectRandomValue());
    }
}