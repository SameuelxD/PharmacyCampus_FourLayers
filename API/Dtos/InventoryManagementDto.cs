using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventoryManagementDto
    {
        public int Id { get; set; }
        public string InventoryManagementId { get; set; }
        public DateTime MovimentDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SellerCode { get; set; }
        public string ReceiverCode { get; set; }
        public int TypeMovimentId { get; set; }
        public int PurchaseMethodId { get; set; }
    }
}