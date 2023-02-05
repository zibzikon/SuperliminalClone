using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Domain.Extensions
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
        
    }
}