using Domain.Skinet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Skinet.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(300);

        builder.Property(p => p.Price)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Picture)
               .IsRequired();

        builder.HasOne(b => b.ProductBrand)
               .WithMany()
               .HasForeignKey(p => p.ProductBrandId);

        builder.HasOne(t => t.ProductType)
               .WithMany()
               .HasForeignKey(p => p.ProductTypeId);
#if DEBUG
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "This is a description for product 1",
                Price = (decimal)new Random().NextDouble(),
                Picture = "https://image.com/placeholder.jpg",
                ProductBrandId = 1,
                ProductTypeId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "This is a description for product 2",
                Price = (decimal)new Random().NextDouble(),
                Picture = "https://image.com/placeholder.jpg",
                ProductBrandId = 1,
                ProductTypeId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Description = "This is a description for product 3",
                Price = (decimal)new Random().NextDouble(),
                Picture = "https://image.com/placeholder.jpg",
                ProductBrandId = 1,
                ProductTypeId = 1
            },
            new Product
            {
                Id = 4,
                Name = "Product 4",
                Description = "This is a description for product 4",
                Price = (decimal)new Random().NextDouble(),
                Picture = "https://image.com/placeholder.jpg",
                ProductBrandId = 1,
                ProductTypeId = 1
            },
            new Product
            {
                Id = 5,
                Name = "Product 5",
                Description = "This is a description for product 5",
                Price = (decimal)new Random().NextDouble(),
                Picture = "https://image.com/placeholder.jpg",
                ProductBrandId = 1,
                ProductTypeId = 1
            }
#endif
        );
    }
}
