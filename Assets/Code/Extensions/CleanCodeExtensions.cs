using System;
using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.Extensions
{
    public static class CleanCodeExtensions
    {
        public static T With<T>(this T obj, Action<T> action)
        {
            action.Invoke(obj);
            return obj;
        }

        public static bool HaveCustomAttribute<T>(this object o) =>
            Attribute.GetCustomAttribute(o.GetType(), typeof(T)) is not null;

        public static GameObject RegisterListeners(this GameObject gameObject, GameEntity entity)
        {
            var listeners = gameObject.GetComponents<IEventListener>();
            
            foreach (var listener in listeners)
                listener.Register(entity);
            
            return gameObject;
        }
        
        public static void MarkCollidedBy(this GameEntity entity, GameEntity by)
            => entity.With(x => x.isCollided = true)
                .With(x => x.ReplaceCollisionID(by.id.Value))
                .With(x => UnityEngine.Debug.Log($"Entity {x} has collided"));
        
        public static void UnmarkCollided(this GameEntity entity)
            => entity.With(x => x.isCollided = false)
                .With(x => x.RemoveCollisionID());
    }
}