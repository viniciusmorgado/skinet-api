using Domain.Skinet.Entities.Base;
using Domain.Skinet.Interfaces;
using Domain.Skinet.Specs;
using Infrastructure.Skinet.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Skinet.Data.Repositories;

public class GenericRepository<T>(StoreContext _context) : IGenericRepository<T> where T : Entity
{
    public async Task<T> GetEntityByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetEntityWithSpecsAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> GetEntityListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetEntityListWithSpecsAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecsEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}
