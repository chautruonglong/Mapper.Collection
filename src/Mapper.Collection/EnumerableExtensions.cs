using System.Collections.Generic;
using System.Linq;

namespace Mapper.Collection
{
    internal static class EnumerableExtensions
    {
        internal static TEnumerable Add<TEnumerable, TElement>(this TEnumerable enumerable, TElement element) where TEnumerable : IEnumerable<TElement>
        {
            var list = enumerable.ToList();
            list.Add(element);
            return (TEnumerable) (IEnumerable<TElement>) list;
        }

        internal static TEnumerable Remove<TEnumerable, TElement>(this TEnumerable enumerable, TElement element) where TEnumerable : IEnumerable<TElement>
        {
            var list = enumerable.ToList();
            list.Remove(element);
            return (TEnumerable) (IEnumerable<TElement>) list;
        }
    }
}