namespace Domain.Entities
{
    public class InventoryManagement:BaseEntity
    {
        public string InventoryManagementId { get; set; }
        public DateTime MovimentDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SellerCode { get; set; }
        public string ReceiverCode { get; set; }
        public int TypeMovimentId { get; set; }
        public int PurchaseMethodId { get; set; }
        public Person People { get; set; }
        public MovementType MovementsTypes { get; set; }
        public PurchaseMethod PurchaseMethods { get; set; }
        public ICollection<MovementDetail> MovementsDetails { get; set; }
        
    }
}