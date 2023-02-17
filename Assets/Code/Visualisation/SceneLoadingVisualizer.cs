using System;
using System.Threading.Tasks;
using Code.Data;
using Code.Data.ResourcesData.Enums;
using Code.Extensions;
using Code.Factories.Interfaces.UI;
using Code.UI.Windows;
using Code.Visualisation.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code.Visualisation
{
    public class SceneLoadingVisualizer : ISceneLoadingVisualizer
    {
        private readonly Transform _sceneTransitionWindowRoot;
        
        private readonly ISceneTransitionWindowFactory _transitionFactory;
        
        private SceneTransitionWindow _transitionWindow;
        
        public SceneLoadingVisualizer(ISceneTransitionWindowFactory transitionFactory)
        {
            _sceneTransitionWindowRoot = CreateRootTransform();
            
            _transitionFactory = transitionFactory;
        }
        
        public async void StartVisualising(AsyncOperation sceneLoadingAsyncOperation)
        {
            sceneLoadingAsyncOperation.allowSceneActivation = false;

            SetTransitionWindow(GetRandomTransition());
            
            await _transitionWindow.EnterTransitionAsync();

            sceneLoadingAsyncOperation.allowSceneActivation = true;

            while (!sceneLoadingAsyncOperation.isDone)
            {
                _transitionWindow.SetProgress(Mathf.RoundToInt(sceneLoadingAsyncOperation.progress * 100));
                await Task.Yield();
            }

            await _transitionWindow.ExitTransitionAsync();
            
            ClearTransitionWindow();
        }

        private SceneTransitionWindow GetRandomTransition() 
            => _transitionFactory.Get((SceneTransitionType)Enum
                .GetValues(typeof(SceneTransitionType))
                .ToTypedEnumerable<int>()
                .SelectRandomValue());

        private void SetTransitionWindow(SceneTransitionWindow transitionWindow)
            => _transitionWindow = transitionWindow
                .With(x => x.transform.SetParent(_sceneTransitionWindowRoot))
                .With(x => x.GetComponent<RectTransform>()
                    .With(r => r.ResetToDefaults()))
                .With(Object.DontDestroyOnLoad);
        
        private void ClearTransitionWindow()
        {
            Object.Destroy(_transitionWindow.gameObject);
            
            _transitionWindow = null;
        }
        
        private static Transform CreateRootTransform()
        {
            return new GameObject(Constants.SceneTransitionWindowRootName)
                .With(x => x.AddComponent<Canvas>())
                .With(x => x.GetComponent<Canvas>()
                    .With(c => c.renderMode = RenderMode.ScreenSpaceOverlay)
                    .With(c => c.sortingOrder = 100))
                .With(x => x.AddComponent<CanvasScaler>())
                .With(x => x.AddComponent<GraphicRaycaster>())
                .With(Object.DontDestroyOnLoad).transform;
        }
    }
}
