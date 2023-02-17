using System;

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

        public static void MarkCollided(this GameEntity entity, GameEntity by)
            => entity.With(x => x.isCollided = true)
                .With(x => x.ReplaceCollisionID(by.id.Value));
        public static void UnmarkCollided(this GameEntity entity)
            => entity.With(x => x.isCollided = false)
                .With(x => x.RemoveCollisionID());
    }
}