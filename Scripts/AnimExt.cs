using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kit
{
    public static class AnimExt
    {
        /// <summary>
        /// Get Item AND index from any IEnumerable instance.
        /// </summary>
        /// <returns>ValueTuple (T item, int index)</returns>
        /// <param name="list">List.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<(T item, int index)> ItemIndex<T>(this IEnumerable<T> list)
        {
            int index = 0;

            foreach (T item in list)
                yield return (item, index++);
        }
    }
}
