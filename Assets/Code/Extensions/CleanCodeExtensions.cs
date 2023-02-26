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
        {
            entity.isCollided = true;
            entity.ReplaceCollidedEntity(by);
        }

        public static void UnmarkCollided(this GameEntity entity)
        {
            entity.isCollided = false;
            
            if(entity.hasCollidedEntity)
                entity.RemoveCollidedEntity();
        }
    }
}