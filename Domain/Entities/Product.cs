

namespace Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrands { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}