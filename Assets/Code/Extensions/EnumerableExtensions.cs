using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Code.Extensions
{
    public static class EnumerableExtensions
    {
        public static T SelectRandomValue<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable as T[] ?? enumerable.ToArray();
            return array[Random.Range(0, array.Count())];
        }

        public static IEnumerable<T> ToTypedEnumerable<T>(this IEnumerable enumerable) 
            => enumerable as T[] ?? enumerable.Cast<T>().ToArray();
        
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
                action(value);
        }

    }
}