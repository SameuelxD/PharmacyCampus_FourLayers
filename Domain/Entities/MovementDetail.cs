namespace Domain.Entities
{
    public class MovementDetail:BaseEntity
    {
        public string InventoryManagementId { get; set; }
        public string InventoryId { get; set; }
        public int QualityUnits { get; set; }
        public double Price { get; set; }
        public Inventory Inventories { get; set; }
        public InventoryManagement InventoriesManagement { get; set; }
    }
}