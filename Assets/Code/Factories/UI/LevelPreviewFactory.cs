using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Data.ResourcesData;
using Code.Factories.Interfaces.UI;
using Code.Infrastructure.Interfaces;
using Code.Services.Interfaces;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Factories.UI
{
    public class LevelPreviewFactory : ILevelPreviewFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly Dictionary<int, LevelPreviewResourceData> _previewImages;

        public LevelPreviewFactory(IAssetsProvider assetsProvider, IEnumerable<LevelPreviewResourceData> levelPreviews)
        {
            _assetsProvider = assetsProvider;
            _previewImages = levelPreviews.ToDictionary(x => x.LevelIndex);
        }

        public Sprite Get(LevelData levelData)
            => _assetsProvider.Get<Sprite>(_previewImages[levelData.Index].SpriteName);

    }
}