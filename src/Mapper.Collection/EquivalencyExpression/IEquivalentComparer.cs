using System;
using System.Linq.Expressions;

namespace Mapper.Collection.EquivalencyExpression
{
    public interface IEquivalentComparer
    {
        int GetHashCode(object obj);
        bool IsEquivalent(object source, object destination);
    }

    public interface IEquivalentComparer<TSource, TDestination> : IEquivalentComparer
    {
        Expression<Func<TDestination, bool>> ToSingleSourceExpression(TSource destination);
    }
}