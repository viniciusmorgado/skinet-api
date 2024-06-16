using Domain.Skinet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Skinet.Data.Mapping;

public class ProductBrandMap : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);
#if DEBUG
        builder.HasData(
            new ProductBrand
            {
                Id = 1,
                Name = "Angular"
            },
            new ProductBrand
            {
                Id = 2,
                Name = "NetCore"
            },
            new ProductBrand
            {
                Id = 3,
                Name = "VS Code"
            },
            new ProductBrand
            {
                Id = 4,
                Name = "React"
            },
            new ProductBrand
            {
                Id = 5,
                Name = "Typescript"
            },
            new ProductBrand
            {
                Id = 6,
                Name = "Redis"
            }
        );
#endif
    }
}
