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
                Name = "Boards"
            },
            new ProductType
            {
                Id = 2,
                Name = "Hats"
            },
            new ProductType
            {
                Id = 3,
                Name = "Boots"
            },
            new ProductType
            {
                Id = 4,
                Name = "Gloves"
            }
        );
#endif
    }
}
