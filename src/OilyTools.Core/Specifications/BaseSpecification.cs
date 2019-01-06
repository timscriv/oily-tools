using System;
using System.Linq.Expressions;
using OilyTools.Core.Interfaces.Specifications;

namespace OilyTools.Core.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Expression { get; }

        public int Limit { get; private set; }
        public int Offset { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;

        protected BaseSpecification() { }

        public BaseSpecification(Expression<Func<TEntity, bool>> expression)
        {
            Expression = expression;
        }

        protected virtual void AddPaging(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
            IsPagingEnabled = true;
        }
    }
}
