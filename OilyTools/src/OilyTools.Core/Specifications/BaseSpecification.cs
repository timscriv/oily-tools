using System;
using System.Linq.Expressions;
using OilyTools.Core.Interfaces.Specifications;

namespace OilyTools.Core.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Expression { get; }
        
        protected BaseSpecification() { }

        public BaseSpecification(Expression<Func<TEntity, bool>> expression)
        {
            Expression = expression;
        }
    }
}
