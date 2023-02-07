using System.Collections.Generic;
using System.Linq;
using Code.Data.Static;
using Code.Domain.Data.Static;
using Code.Domain.Factories;
using Code.Domain.Infrastructure.Interfaces;
using Code.Domain.UI.Interfaces;
using Code.Infrastructure;

namespace Code.Domain.Regestration.Installers
{
    public class SceneTransitionWindowFactory : ISceneTransitionWindowFactory
    {
        private readonly IAssetsProvider _assetsProvider;
        private readonly IViewService _viewService;
        private readonly Dictionary<SceneTransitionType, SceneTransitionStaticData> _transitions;

        public SceneTransitionWindowFactory(IAssetsProvider assetsProvider,
            IEnumerable<SceneTransitionStaticData> transitions, IViewService viewService)
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