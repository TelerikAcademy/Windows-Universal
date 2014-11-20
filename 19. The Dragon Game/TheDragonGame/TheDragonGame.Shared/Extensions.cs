using System;
using System.Collections.Generic;
using System.Text;

namespace TheDragonGame
{
    public static class Extensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }

        }
    }
}
