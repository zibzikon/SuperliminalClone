using Code.Game.Interfaces;
using UnityEngine;

namespace Code.Extensions
{
    public static class GameObjectExtensions
    {
        public static GameObject RegisterListeners(this GameObject gameObject, GameEntity entity)
        {
            var listeners = gameObject.GetComponents<IEventListener>();
            
            foreach (var listener in listeners)
                listener.Register(entity);
            
            return gameObject;
        }
    }
}