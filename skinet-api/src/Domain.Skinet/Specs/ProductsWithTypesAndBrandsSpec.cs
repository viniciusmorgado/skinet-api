using Domain.Skinet.Entities;
using Domain.Skinet.Specs.Base;

namespace Domain.Skinet.Specs;

public class ProductsWithTypesAndBrandsSpec : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpec()
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}
