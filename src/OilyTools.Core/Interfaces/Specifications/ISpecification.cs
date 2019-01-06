using System;
using System.Linq.Expressions;

namespace OilyTools.Core.Interfaces.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Expression { get; }

        int Limit { get;}
        int Offset { get; }
        bool IsPagingEnabled { get; }
    }
}
