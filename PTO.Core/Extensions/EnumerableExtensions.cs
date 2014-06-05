using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PTO.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var i in items)
                action(i);
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items, int chunkSize)
        {
            var chunk = new List<T>();

            foreach (var i in items)
            {
                chunk.Add(i);
                if (chunk.Count == chunkSize)
                {
                    yield return chunk;
                    chunk = new List<T>();
                }
            }
            if (chunk.Count > 0)
                yield return chunk;
        }

        public static Tuple<IEnumerable<T>, IEnumerable<T>> Partition<T>(this IEnumerable<T> items, Func<T, bool> f)
        {
            var trues = new List<T>();
            var falses = new List<T>();

            foreach (var i in items)
            {
                if (f(i))
                    trues.Add(i);
                else
                    falses.Add(i);
            }

            return new Tuple<IEnumerable<T>, IEnumerable<T>>(trues, falses);
        }

        public static PropertyInfo[] VisibleProperties(this IEnumerable enumerable)
        {
            var type = enumerable.GetType();
            var elementType = type.GetElementType() ?? type.GetGenericArguments()[0];
            return elementType.GetProperties();
        }
    }
}
