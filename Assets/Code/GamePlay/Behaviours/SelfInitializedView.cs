using Code.Attributes.Injection;
using Code.Extensions;
using UnityEngine;
using Zenject;

namespace Code.Game.ViewVisteners
{
    [RequireComponent(typeof(UnityViewController))]
    [ImplicitInjectable]
    public class SelfInitializedView : MonoBehaviour
    {
        private UnityViewController _viewController;
        private GameContext _gameContext;

        [Inject]
        public void Construct(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        private void Awake()
        {
            _viewController = GetComponent<UnityViewController>();
            var entity = _gameContext.CreateEntity();
            
            _viewController.Initialize(entity, _gameContext);
            gameObject.RegisterListeners(entity);
        }
    }
}