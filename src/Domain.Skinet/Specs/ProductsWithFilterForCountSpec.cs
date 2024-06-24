using Domain.Skinet.Entities;
using Domain.Skinet.Specs.Base;

namespace Domain.Skinet.Specs;

public class ProductsWithFilterForCountSpec : Specification<Product>
{
    public ProductsWithFilterForCountSpec(ProductsParamsSpec productParams) : base(x => 
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains (productParams.Search)) &&
        (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
        (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
    {

    }
}
