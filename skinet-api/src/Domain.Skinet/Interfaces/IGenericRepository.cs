using Domain.Skinet.Entities.Base;
using Domain.Skinet.Specs;

namespace Domain.Skinet.Interfaces;

public interface IGenericRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetEntityWithSpecs(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
}
