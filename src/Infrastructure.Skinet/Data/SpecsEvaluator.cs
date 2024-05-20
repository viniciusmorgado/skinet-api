using Domain.Skinet.Entities.Base;
using Domain.Skinet.Specs;
using Microsoft.EntityFrameworkCore;

namespace Api.Skinet.Data;

public class SpecsEvaluator<TEntity> where TEntity : Entity 
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // p => p.ProducTypeId.Equals(id);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }
}
