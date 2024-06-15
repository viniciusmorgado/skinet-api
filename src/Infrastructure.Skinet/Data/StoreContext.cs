using System.Reflection;
using Domain.Skinet.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Skinet.Data;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public StoreContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=skinet; Username=postgres; Password=postgres");
    }
}
