using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public int ProductBrandId { get; set; }
    }
}