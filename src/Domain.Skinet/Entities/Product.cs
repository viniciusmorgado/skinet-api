using Domain.Skinet.Entities.Base;

namespace Domain.Skinet.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Picture { get; set; }


    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    
    public int ProductBrandId { get; set; }
    public ProductBrand ProductBrand { get; set; }
}
