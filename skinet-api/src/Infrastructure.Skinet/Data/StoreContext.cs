using Domain.Skinet.Entities;
using Infrastructure.Skinet.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Api.Skinet.Data;

public partial class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMap());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
