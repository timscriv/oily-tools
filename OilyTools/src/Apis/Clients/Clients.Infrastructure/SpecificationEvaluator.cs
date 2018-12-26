using OilyTools.Core.Interfaces.Specifications;
using System.Linq;

namespace Clients.Infrastructure
{
    public static class SpecificationEvaluator<TEntity>
    {
        //https://github.com/dotnet-architecture/eShopOnWeb/blob/04530db118d2aca71150e3e71fab399b9c172705/src/Infrastructure/Data/SpecificationEvaluator.cs
        public static IQueryable<TEntity> ApplySpecification(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            if (specification == null) return inputQuery;

            var query = inputQuery;

            if (specification.Expression != null)
                query = query.Where(specification.Expression);

            return query;
        }
    }
}
