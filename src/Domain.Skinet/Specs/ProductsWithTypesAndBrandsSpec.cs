using Domain.Skinet.Entities;
using Domain.Skinet.Specs.Base;

namespace Domain.Skinet.Specs;

public class ProductsWithTypesAndBrandsSpec : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpec(string sort, int? brandId, int? typeId) : base(x => 
        (!brandId.HasValue || x.ProductBrandId == brandId) && (!typeId.HasValue || x.ProductTypeId == typeId))
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        AddOrderBy(x => x.Name);

        if(!string.IsNullOrEmpty(sort))
        {
            switch (sort)
            {
                // both via price
                case "ASC":
                    AddOrderBy(p => p.Price);
                    break;
                case "DESC":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }

    public ProductsWithTypesAndBrandsSpec(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}
