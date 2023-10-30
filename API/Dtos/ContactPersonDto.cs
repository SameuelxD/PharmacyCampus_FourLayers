using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ContactPersonDto
    {
        public int Id { get; set; }
        public string PersonCode { get; set; }
        public int TypeContactId { get; set; }
    }
}