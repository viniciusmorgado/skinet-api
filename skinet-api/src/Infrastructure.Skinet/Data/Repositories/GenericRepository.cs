using Api.Skinet.Data;
using Domain.Skinet.Entities.Base;
using Domain.Skinet.Interfaces;
using Domain.Skinet.Specs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Skinet.Repositories;

public class GenericRepository<T>(StoreContext _context) : IGenericRepository<T> where T : Entity
{
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetEntityWithSpecs(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(); 
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecsEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}
