using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DocumentType:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
    }
}