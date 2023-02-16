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
            Attribute.GetCustomAttribute(typeof(T), o.GetType()) is not null;
    }
}