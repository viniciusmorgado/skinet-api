// using Api.Skinet.Data;
// using Domain.Skinet.Entities;
// using Domain.Skinet.Interfaces;
// using Infrastructure.Skinet.Data;
// using Microsoft.EntityFrameworkCore;

// namespace Infrastructure.Skinet.Data.Repositories;

// public class ProductRepository(StoreContext _context) : IProductRepository
// {
//     public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
//     {
//         return await _context.ProductBrands.ToListAsync();
//     }

//     public async Task<Product> GetProductByIdAsync(int id)
//     {
//         return await _context.Products.Include(p => p.ProductType)
//                                       .Include(p => p.ProductBrand)
//                                       .FirstOrDefaultAsync(p => p.Id.Equals(id));
//     }

//     public async Task<IReadOnlyList<Product>> GetProductsAsync()
//     {
//         return await _context.Products.Include(p => p.ProductType)
//                                       .Include(p => p.ProductBrand)
//                                       .ToListAsync();
//     }

//     public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
//     {
//         return await _context.ProductTypes.ToListAsync();
//     }
// }
