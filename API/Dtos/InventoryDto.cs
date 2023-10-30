using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string InventoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public string ProductCode { get; set; }
        public int PresentationTypeId { get; set; }
    }
}