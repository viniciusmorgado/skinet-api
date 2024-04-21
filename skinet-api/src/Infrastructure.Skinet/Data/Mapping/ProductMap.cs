using Domain.Skinet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Skinet.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(36);
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Product 1"
            },
            new Product
            {
                Id = 2,
                Name = "Product 2"
            },
            new Product
            {
                Id = 3,
                Name = "Product 3"
            }
        );
    }
}
