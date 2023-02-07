using Code.Domain.Data.Static;
using Code.Domain.Infrastructure.Interfaces;
using Code.Infrastructure;

namespace Code.Domain
{
    public class MainMenuFactory : IMainMenuFactory
    {
        private readonly GameStaticData _gameStaticData;
        private readonly IAssetsProvider _assetsProvider;
        private readonly IViewService _viewService;

        public MainMenuFactory(GameStaticData gameStaticData, IAssetsProvider assetsProvider, IViewService viewService)
        {
            _gameStaticData = gameStaticData;
            _assetsProvider = assetsProvider;
            _viewService = viewService;
        }
        
        public IMainMenu Create()
            => _viewService.CreateView(_assetsProvider.Get<MainMenu>(_gameStaticData.MainMenuPrefabName));
    }
}   