using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MovementDetailDto
    {
        public int Id { get; set;}
        public string InventoryManagementId { get; set; }
        public string InventoryId { get; set; }
        public int QualityUnits { get; set; }
        public double Price { get; set; }
    }
}