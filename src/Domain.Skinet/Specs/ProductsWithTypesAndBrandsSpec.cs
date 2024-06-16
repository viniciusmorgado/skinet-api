using System.Linq.Expressions;
using Domain.Skinet.Entities;
using Domain.Skinet.Specs.Base;

namespace Domain.Skinet.Specs;

public class ProductsWithTypesAndBrandsSpec : Specification<Product>
{
    public ProductsWithTypesAndBrandsSpec(string sort)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        AddOrderBy(x => x.Name);
        // AddOrderByDescending(x => x.Name);
    }

    public ProductsWithTypesAndBrandsSpec(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}
