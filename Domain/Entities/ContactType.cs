using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactType:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ContactPerson> ContactPeople { get; set; }
    }
}