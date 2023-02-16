using Code.Data;
using Code.Data.ResourcesData;
using Code.Factories.Interfaces.UI;
using Code.Infrastructure.Interfaces;
using Code.Mediators;
using Code.Services.Interfaces;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Factories.UI
{
    public class LevelSelectableUIControlFactory : ILevelSelectableUIControlFactory
    {
        private readonly UIResourcesData _uiResourcesData;
        private readonly IAssetsProvider _assetsProvider;
        private readonly ILevelPreviewFactory _levelPreviewFactory;

        public LevelSelectableUIControlFactory(UIResourcesData uiResourcesData,
            IAssetsProvider assetsProvider, ILevelPreviewFactory levelPreviewFactory)
        {
            _uiResourcesData = uiResourcesData;
            _assetsProvider = assetsProvider;
            _levelPreviewFactory = levelPreviewFactory;
        }
        
        public LevelSelectableUIControl Get(LevelData levelData, MainMediator mainMediator)
        {
            var prefab = _assetsProvider.Get<LevelSelectableUIControl>(_uiResourcesData.LevelSelectableUIControlPrefabName);
            var instance = Object.Instantiate(prefab);
            instance.InitializeView(levelData, mainMediator, _levelPreviewFactory.Get(levelData));
            
            return instance;
        }
    }
}