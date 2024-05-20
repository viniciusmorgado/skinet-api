using Domain.Skinet.Entities.Base;
using Domain.Skinet.Specs;

namespace Domain.Skinet.Interfaces;

public interface IGenericRepository<T> where T : Entity
{
    Task<T> GetEntityByIdAsync(int id);
    Task<IReadOnlyList<T>> GetEntityListAsync();
    Task<T> GetEntityWithSpecsAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetEntityListWithSpecsAsync(ISpecification<T> spec);
}
