using Domain.Skinet.Entities;
using Domain.Skinet.Specs.Base;

namespace Domain.Skinet.Specs;

public class ProductsWithTypesAndBrandsSpec : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpec(ProductsParamsSpec productParams) : base(x => 
        (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
        (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        AddOrderBy(x => x.Name);
        ApplyPaging(productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);
    
        if(!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
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
