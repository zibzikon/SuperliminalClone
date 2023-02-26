using Code.Extensions;
using Code.GamePlay.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class CollidersActivationListener : MonoBehaviour, IEventListener, ICollidersDisabledListener, ICollidersDisabledRemovedListener
    {
        [Required, SerializeField] private UnityViewController _viewController;
        
        public void Register(GameEntity entity)
        {
            entity.AddCollidersDisabledListener(this);
            entity.AddCollidersDisabledRemovedListener(this);
        }
        
        public void Unregister(GameEntity entity)
        {
            entity.RemoveCollidersDisabledListener(this);
            entity.RemoveCollidersDisabledRemovedListener(this);
        }

        public void OnCollidersDisabled(GameEntity entity)
        {
            _viewController.Colliders.ForEach(x => x.enabled = false);
           
            if (!entity.hasCollidedEntity) return;
            entity.collidedEntity.Value.UnmarkCollided();
            entity.UnmarkCollided();
        }
        public void OnCollidersDisabledRemoved(GameEntity entity)
            => _viewController.Colliders.ForEach(x => x.enabled = true);
    }
}