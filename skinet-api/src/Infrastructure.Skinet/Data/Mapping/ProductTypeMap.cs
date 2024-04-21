using Domain.Skinet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Skinet.Data.Mapping;

public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);
#if DEBUG
        builder.HasData(
            new ProductType
            {
                Id = 1,
                Name = "Product Type 1"
            },
            new ProductType
            {
                Id = 2,
                Name = "Product Type 2"
            },
            new ProductType
            {
                Id = 3,
                Name = "Product Type 3"
            },
            new ProductType
            {
                Id = 4,
                Name = "Product Type 4"
            },
            new ProductType
            {
                Id = 5,
                Name = "Product Type 5"
            }
        );
#endif
    }
}
