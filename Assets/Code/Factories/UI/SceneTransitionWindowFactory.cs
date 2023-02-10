using System.Collections.Generic;
using System.Linq;
using Code.Data.ResourcesData;
using Code.Data.ResourcesData.Enums;
using Code.Factories.Interfaces.UI;
using Code.Infrastructure.Interfaces;
using Code.UI.Windows;

namespace Code.Factories.UI
{
    public class SceneTransitionWindowFactory : ISceneTransitionWindowFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IViewService _viewService;
        private readonly Dictionary<SceneTransitionType, SceneTransitionResourceData> _transitions;

        public SceneTransitionWindowFactory(IAssetsProvider assetsProvider,
            IEnumerable<SceneTransitionResourceData> transitions, IViewService viewService)
        {
            _assetsProvider = assetsProvider;
            _viewService = viewService;
            _transitions = transitions.ToDictionary(x => x.TransitionType);
        }

        public SceneTransitionWindow Get(SceneTransitionType type)
            => _viewService.CreateView(_assetsProvider
                .Get<SceneTransitionWindow>(_transitions[type].TransitionAssetName));
    }
}