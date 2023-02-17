using Code.Attributes.Injection;
using Code.Extensions;
using UnityEngine;
using Zenject;

namespace Code.Game.ViewVisteners
{
    [RequireComponent(typeof(UnityViewController))]
    [ImplicitInjectableView]
    public class SelfInitializedView : MonoBehaviour
    {
        private UnityViewController _viewController;

        [Inject]
        public void Construct(GameContext gameContext)
        {
            _viewController = GetComponent<UnityViewController>();
            var entity = gameContext.CreateEntity();
            
            _viewController.Initialize(entity, gameContext);
            gameObject.RegisterListeners(entity);
        }
    }
}