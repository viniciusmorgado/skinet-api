using Domain.Skinet.Entities;

namespace Domain.Skinet.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
}
