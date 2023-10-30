using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class BillDto
    {
        public int Id { get; set; }
        public int InitialInvoice { get; set; }
        public int FinalBill { get; set; }
        public int CurrentInvoice { get; set; }
        public string ResolutionNumber { get; set; }
    }
}