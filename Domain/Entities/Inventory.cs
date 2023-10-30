namespace Domain.Entities
{
    public class Inventory:BaseEntity
    {
        public string InventoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public string ProductCode { get; set; }
        public int PresentationTypeId { get; set; }
        public Product Products { get; set; }
        public PresentationType PresentationsTypes { get; set; } 
        public ICollection<MovementDetail> MovementsDetails { get; set; }
    }

}