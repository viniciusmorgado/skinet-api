using Api.Skinet.Data;
using Domain.Skinet.Entities;
using Domain.Skinet.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Skinet.Repositories;

public class ProductRepository(StoreContext _context) : IProductRepository
{
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
