namespace Domain.Entities;
    public class Bill:BaseEntity
    {
        public int InitialInvoice { get; set; }
        public int FinalBill { get; set; }
        public int CurrentInvoice { get; set; }
        public string ResolutionNumber { get; set; }
    }
