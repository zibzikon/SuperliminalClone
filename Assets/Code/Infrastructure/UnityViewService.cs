using System.Collections.Generic;
using Code.Domain;
using Code.Domain.Extensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Infrastructure
{
    public class UnityViewService : IViewService
    {
        private readonly Transform _unityViewsRootTransform;
        private readonly Transform _uisRootTransform;
        
        private List<Object> _unityViews = new();
        private List<Object> _uis = new();
        
        public UnityViewService()
        {
            _unityViewsRootTransform = CreateUnityViewRootTransform();
            _uisRootTransform = CreateUIRootTransform();
            
        }
        
        public T CreateView<T>(T viewPrefab) where T : Object
            => Object.Instantiate(viewPrefab, _unityViewsRootTransform);
        

        public T CreateUI<T>(T uiPrefab) where T : Object
            => Object.Instantiate(uiPrefab, _uisRootTransform);
        
        public void Cleanup()
        {
            _unityViews.ForEach(x => Object.Destroy(x.GameObject()));
            _uis.ForEach(x => Object.Destroy(x.GameObject()));
        }

        private static Transform CreateUnityViewRootTransform() =>
            new GameObject(Constants.UnityViewRootName).transform;
        
        private static Transform CreateUIRootTransform()
        {
            return new GameObject(Constants.UIRootName)
                .With(x => x.AddComponent<Canvas>())
                .With(x => x.GetComponent<Canvas>()
                    .With(c => c.renderMode = RenderMode.ScreenSpaceOverlay)
                    .With(c => c.sortingOrder = 100))
                .With(x => x.AddComponent<CanvasScaler>())
                .With(x => x.AddComponent<GraphicRaycaster>()).transform;
        }
    }
}